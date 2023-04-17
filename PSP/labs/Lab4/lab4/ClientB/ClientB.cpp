#include "Winsock2.h"
#include<iostream>
#include<string.h>
#include<tchar.h>
#pragma warning(disable:4996)
#pragma comment(lib,"WS2_32.lib")
#define INADDR_ANY        (u_long)0x00000000 //любой адрес       +++ 
#define INADDR_LOOPBACK    0x7f000001        // внутренняя петля +++
#define INADDR_BROADCAST  (u_long)0xffffffff // широковещание    +++  
#define INADDR_NONE        0xffffffff        // нет адреса  
#define ADDR_ANY           INADDR_ANY        // любой адрес       



using namespace std;

string  GetErrorMsgText(int code)		//Формирование текста ошибки
{
	string msgText;
	switch (code)                      // проверка кода возврата  
	{
	case WSAEINTR: msgText = "WSAEINTR"; break;
	case WSAEACCES: msgText = "WSAEACCES"; break;
	case WSAEFAULT: msgText = "WSAEFAULT"; break;
	case WSAEINVAL: msgText = "WSAEINVAL"; break;
	case WSAEMFILE: msgText = "WSAEMFILE"; break;
	case WSAEWOULDBLOCK:msgText = "WSAEWOULDBLOCK"; break;
	case WSAEINPROGRESS:msgText = "WSAEINPROGRESS"; break;
	case WSAENOTSOCK:msgText = "WSAENOCTSOCK"; break;
	case WSAEDESTADDRREQ:msgText = "WSAEDESTADDRREQ"; break;
	case WSAEMSGSIZE:msgText = "WSAEMSGSIZE"; break;
	case WSAEPROTOTYPE:msgText = "WSAEPROTOTYPE"; break;
	case WSAENOPROTOOPT:msgText = "WSAENOPROTOOPT"; break;
	case WSAEPROTONOSUPPORT:msgText = "WSAEPROTONOSUPPORT"; break;
	case WSAESOCKTNOSUPPORT:msgText = "WSAESOCKTNOSUPPORT"; break;
	case WSAEOPNOTSUPP:msgText = "WSAEOPNOTSUPP"; break;
	case WSAEPFNOSUPPORT:msgText = "WSAEPFNOSUPPORT"; break;
	case WSAEAFNOSUPPORT:msgText = "WSAEAFNOSUPPORT"; break;
	case WSAEADDRINUSE:msgText = "WSAEADDRINUSE"; break;
	case WSAEADDRNOTAVAIL:msgText = "WSAEADDRNOTAVAIL"; break;
	case WSAENETDOWN:msgText = "WSAENETDOWN"; break;
	case WSAENETUNREACH:msgText = "WSAENETUNREACH"; break;
	case WSAENETRESET:msgText = "WSAENETRESET"; break;
	case WSAECONNABORTED:msgText = "WSAECONNABORTED"; break;
	case WSAECONNRESET:msgText = "WSAECONNRESET"; break;
	case WSAENOBUFS:msgText = "WSAENOBUFS"; break;
	case WSAEISCONN:msgText = "WSAEISCONN"; break;
	case WSAENOTCONN:msgText = "WSAENOTCONN"; break;
	case WSAESHUTDOWN:msgText = "WSAESHUTDOWN"; break;
	case WSAETIMEDOUT:msgText = "WSAETIMEDOUT"; break;
	case WSAECONNREFUSED:msgText = "WSAECONNREFUSED"; break;
	case WSAEHOSTDOWN:msgText = "WSAEHOSTDOWN"; break;
	case WSAEHOSTUNREACH:msgText = "WSAEHOSTUNREACH"; break;
	case WSAEPROCLIM:msgText = "WSAEPROCLIM"; break;
	case WSASYSNOTREADY:msgText = "WSASYSNOTREADY"; break;
	case WSAVERNOTSUPPORTED:msgText = "WSAVERNOTSUPPORTED"; break;
	case WSANOTINITIALISED:msgText = "WSANOTINITIALISED"; break;
	case WSAEDISCON:msgText = "WSAEDISCON"; break;
	case WSATYPE_NOT_FOUND:msgText = "WSATYPE_NOT_FOUND"; break;
	case WSAHOST_NOT_FOUND:msgText = "WSAHOST_NOT_FOUND"; break;
	case WSATRY_AGAIN:msgText = "WSATRY_AGAIN"; break;
	case WSANO_RECOVERY:msgText = "WSANO_RECOVERY"; break;
	case WSANO_DATA:msgText = "WSANO_DATA"; break;
	case WSA_INVALID_HANDLE:msgText = "WSA_INVALID_HANDLE"; break;
	case WSA_INVALID_PARAMETER:msgText = "WSA_INVALID_PARAMETER"; break;
	case WSA_IO_INCOMPLETE:msgText = "WSA_IO_INCOMPLETE"; break;
	case WSA_IO_PENDING:msgText = "WSA_IO_PENDING"; break;
	case WSA_NOT_ENOUGH_MEMORY:msgText = "WSA_NOT_ENOUGH_MEMORY"; break;
	case WSA_OPERATION_ABORTED:msgText = "WSA_OPERATION_ABORTED"; break;
	case WSAEINVALIDPROCTABLE:msgText = "WSAEINVALIDPROCTABLE"; break;
	case WSAEINVALIDPROVIDER:msgText = "WSAEINVALIDPROVIDER"; break;
	case WSAEPROVIDERFAILEDINIT:msgText = "WSAEPROVIDERFAILEDINIT"; break;
	case WSASYSCALLFAILURE:msgText = "WSASYSCALLFAILURE"; break;
	default: msgText = "***ERROR***"; break;
	};
	return msgText;
};
string  SetErrorMsgText(string msgText, int code)
{
	return  msgText + GetErrorMsgText(code);
};
bool  GetServer(
	char* call, //[in] позывной сервера  
	short            port, //[in] номер порта сервера    
	struct sockaddr* from, //[out] указатель на SOCKADDR_IN
	int* flen  //[out] указатель на размер from 
)
{
	SOCKET cC;

	if ((cC = socket(AF_INET, SOCK_DGRAM, NULL)) == INVALID_SOCKET)
		throw  SetErrorMsgText("socket:", WSAGetLastError());

	int optval = 1;
	if (setsockopt(cC, SOL_SOCKET, SO_BROADCAST,(char*)&optval, sizeof(int)) == SOCKET_ERROR)
		throw  SetErrorMsgText("opt:", WSAGetLastError());

	SOCKADDR_IN all;                        // параметры  сокета sS
	all.sin_family = AF_INET;               // используется IP-адресация  
	all.sin_port = htons(port);             // порт 2000
	//all.sin_addr.s_addr = INADDR_BROADCAST; // всем 
	all.sin_addr.s_addr = inet_addr("192.168.85.255");
	int sendlen;
	if ((sendlen = sendto(cC, (char*)"Hello", sizeof("Hello") + 1, NULL, (sockaddr*)&all, sizeof(all))) == SOCKET_ERROR)
		throw  SetErrorMsgText("sendto:", WSAGetLastError());

	int  libuf = 0;
	char ibuf[50] = "";

	if ((libuf = recvfrom(cC, ibuf, sizeof(ibuf), NULL, from, flen)) == SOCKET_ERROR) {
		if (libuf == WSAETIMEDOUT)
			return false;
		else 
			throw  SetErrorMsgText("recvfrom:", WSAGetLastError());
	}

	std::cout << "\nServer name: " << ibuf;
	SOCKADDR_IN* addr = (SOCKADDR_IN*)&from;
	std::cout << "\nPort: " << ntohs(addr->sin_port);
	std::cout << "\nIP: " << inet_ntoa(addr->sin_addr);

	hostent* shostname = gethostbyaddr((char*)&((SOCKADDR_IN*)from)->sin_addr, sizeof(SOCKADDR_IN), AF_INET);
	cout << "\n\tIP: " << inet_ntoa(((SOCKADDR_IN*)from)->sin_addr) << endl;
	cout << "\tPort: " << ntohs(((sockaddr_in*)from)->sin_port) << endl;
	cout << "\tHostname: " << shostname->h_name << endl;
	return true;
}
int main(int argc, _TCHAR* argv[])
{
	setlocale(LC_CTYPE, "ru");
	SOCKET  cC;           // дескриптор сокета 
	WSADATA wsaData;
	try
	{
		if (WSAStartup(MAKEWORD(2, 0)/*версия winsock*/, &wsaData) != 0)
			throw  SetErrorMsgText("Startup:", WSAGetLastError());
		if ((cC = socket(AF_INET, SOCK_DGRAM, NULL)) == INVALID_SOCKET)	//сокет не подключен
			throw  SetErrorMsgText("socket:", WSAGetLastError());

		SOCKADDR_IN SOCKADR;
		int len = sizeof(SOCKADR);
		char name[] = "Hello";
		GetServer(name, 2000, (sockaddr*)&SOCKADR, &len);
		//GetServer(name, 2000, (sockaddr*)&SOCKADR, &len);
		/*for (int ;;)
		{*/
			//GetServer(name, 2000, (sockaddr*)&SOCKADR, &len);
		//}
		if (closesocket(cC) == SOCKET_ERROR)
			throw  SetErrorMsgText("closesocket:", WSAGetLastError());
		if (WSACleanup() == SOCKET_ERROR)
			throw  SetErrorMsgText("Cleanup:", WSAGetLastError());
	}
	catch (string errorMsgText)
	{
		cout << endl << errorMsgText;
	}
	system("pause");
	return 0;
}
