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

SOCKADDR_IN SOCKADR;
SOCKET sS;
bool  GetRequestFromClient(
	char* name, //[in] позывной сервера  
	short            port, //[in] номер просушиваемого порта 
	struct sockaddr* from, //[out] указатель на SOCKADDR_IN
	int* flen  //[out] указатель на размер from 
) {

	SOCKADDR_IN serv;
	serv.sin_family = AF_INET;
	serv.sin_port = htons(port);
	serv.sin_addr.s_addr = INADDR_ANY;

	int libuf = 0, lobuf = 0;
	char ibuf[50];

	if ((sS = socket(AF_INET, SOCK_DGRAM, NULL)) == INVALID_SOCKET) {
		throw  SetErrorMsgText("socket: ", WSAGetLastError());
	}

	if (bind(sS, (LPSOCKADDR)&serv, sizeof(serv)) == SOCKET_ERROR)
	{
		throw  SetErrorMsgText("bind:", WSAGetLastError());
	}


	if ((libuf = recvfrom(sS, ibuf, sizeof(ibuf), NULL, from, flen)) == SOCKET_ERROR) {
		if (WSAGetLastError() == WSAETIMEDOUT) 
			return false;
		throw SetErrorMsgText("recv: ", WSAGetLastError());
	}

	if (strcmp(ibuf, name) == 0) {
		std::cout << "Name matches";
		return true;
	}
	else {
		std::cout << "Error name";
		return false;
	}

}

bool  PutAnswerToClient(
	char* name, //[in] позывной сервера  
	struct sockaddr* to,   //[in] указатель на SOCKADDR_IN
	int* lto   //[in] указатель на размер from 
)
{
	int lobuf;
	if ((lobuf = sendto(sS, name, strlen(name) + 1, NULL, to, *lto)) == SOCKET_ERROR)
			throw  SetErrorMsgText("sendto:", WSAGetLastError());
}
void GetServer(char* call, short port, struct sockaddr* from, int* flen) {
	SOCKET cC;
	SOCKADDR_IN all;
	all.sin_family = AF_INET;
	all.sin_port = htons(port);
	all.sin_addr.s_addr = INADDR_BROADCAST;
	//all.sin_addr.s_addr = inet_addr("192.168.204.37");
	int timeout = 500;
	int countServers = 1;
	int optval = 1;
	char buf[50];

	try {
		if ((cC = socket(AF_INET, SOCK_DGRAM, NULL)) == INVALID_SOCKET) {
			throw  SetErrorMsgText("socket:", WSAGetLastError());
		}
		if (setsockopt(cC, SOL_SOCKET, SO_BROADCAST, (char*)&optval, sizeof(int)) == SOCKET_ERROR) {
			throw  SetErrorMsgText("setsocketopt:", WSAGetLastError());
		}
		if (setsockopt(cC, SOL_SOCKET, SO_RCVTIMEO, (char*)&timeout, sizeof(int)) == SOCKET_ERROR) {
			throw  SetErrorMsgText("setsocketopt:", WSAGetLastError());
		}
		from = (sockaddr*)&all;
		if (sendto(cC, call, strlen(call) + 1, NULL, (sockaddr*)&all, sizeof(all)) == SOCKET_ERROR) {
			throw SetErrorMsgText("sendto:", WSAGetLastError());
		}
		if (recvfrom(cC, buf, sizeof(buf), NULL, from, flen) == SOCKET_ERROR) {
			throw  SetErrorMsgText("recvfrom:", WSAGetLastError());
		}
		if (strcmp(call, buf) == 0) {
			countServers++;
			cout << "Server N" << countServers;
			hostent* shostname = gethostbyaddr((char*)&((SOCKADDR_IN*)from)->sin_addr, sizeof(SOCKADDR_IN), AF_INET);
			cout << "\tIP: " << inet_ntoa(((SOCKADDR_IN*)from)->sin_addr) << endl;
			cout << "\t\tPort: " << ntohs(((struct sockaddr_in*)from)->sin_port) << endl;
			cout << "\t\tHostname: " << shostname->h_name << endl;
		}
	}
	catch (string errorMsgText)
	{
		if (WSAGetLastError() == WSAETIMEDOUT) {
			cout << "Total number of servers with that callsign: " << countServers << endl;
			if (closesocket(cC) == SOCKET_ERROR) throw SetErrorMsgText("closesocket: ", WSAGetLastError());
		}
		else throw SetErrorMsgText("GetServer:", WSAGetLastError());
	}
}
int main(int argc, _TCHAR* argv[])
{
	setlocale(LC_CTYPE, "ru");
	WSADATA wsaData;
	SOCKADDR_IN sokr;
	try
	{
		if (WSAStartup(MAKEWORD(2, 0)/*версия winsock*/, &wsaData) != 0)
			throw  SetErrorMsgText("Startup:", WSAGetLastError());
		if ((sS = socket(AF_INET, SOCK_DGRAM, NULL)) == INVALID_SOCKET)
			throw  SetErrorMsgText("socket:", WSAGetLastError());

		char name[] = "Hello";
		char ERROr[] = "ERROR NAME";
		memset(&SOCKADR, 0, sizeof(SOCKADR));
		int len = sizeof(SOCKADR);
		bool getreq = true;
		bool putans = true;
		int l = sizeof(sokr);
		GetServer(name, 2000, (sockaddr*)&sokr, &l);
		while(true){
 			if (getreq=GetRequestFromClient(name, 2000, (sockaddr*)&SOCKADR, &len))
				putans=PutAnswerToClient(name, (sockaddr*)&SOCKADR, &len);
			else {
				cout << endl << PutAnswerToClient(ERROr, (sockaddr*)&SOCKADR, &len);
			}
			if (closesocket(sS) == SOCKET_ERROR)
				throw  SetErrorMsgText("closesocket:", WSAGetLastError());
		}
		if (WSACleanup() == SOCKET_ERROR)
			throw  SetErrorMsgText("Cleanup:", WSAGetLastError());
	}
	catch (string errorMsgText)
	{
		cout << endl << errorMsgText;

	}
	system("pause");
	main(0, {});
}

