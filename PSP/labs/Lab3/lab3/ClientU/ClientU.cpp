#include "Winsock2.h"
#include<iostream>
#include<string.h>
#include<tchar.h>
#pragma warning(disable:4996)
#pragma comment(lib,"WS2_32.lib")
#define INADDR_ANY        (u_long)0x00000000 //����� �����       +++ 
#define INADDR_LOOPBACK    0x7f000001        // ���������� ����� +++
#define INADDR_BROADCAST  (u_long)0xffffffff // �������������    +++  
#define INADDR_NONE        0xffffffff        // ��� ������  
#define ADDR_ANY           INADDR_ANY        // ����� �����       



using namespace std;

string  GetErrorMsgText(int code)		//������������ ������ ������
{
	string msgText;
	switch (code)                      // �������� ���� ��������  
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



int main(int argc, _TCHAR* argv[])
{
	setlocale(LC_CTYPE, "ru");
	SOCKET  cC;           // ���������� ������ 
	WSADATA wsaData;
	try
	{
		if (WSAStartup(MAKEWORD(2, 0)/*������ winsock*/, &wsaData) != 0)
			throw  SetErrorMsgText("Startup:", WSAGetLastError());
		if ((cC = socket(AF_INET, SOCK_DGRAM, NULL)) == INVALID_SOCKET)	//����� �� ���������
			throw  SetErrorMsgText("socket:", WSAGetLastError());

		SOCKADDR_IN serv;              // ���������  ������ �������
		serv.sin_family = AF_INET;    // ������������ ip-���������  
		serv.sin_port = htons(2000);   // ���� 2000
		//serv.sin_addr.s_addr = inet_addr("127.0.0.1"); // ����� �������  
		serv.sin_addr.s_addr = inet_addr("192.168.31.110");
		char obuf[50] = "Hello";   //����� ������
		char temp[50];
		int  lobuf = 0;                    //���������� ������������  
		int libuf = 0;						//���������� ���������� ����

		int counter;
		cout << "������� ����������� ���������� ��������� : \n";
		cin >> counter;
		do {
			char tempArr[50] = "Hello from Client";
			char temp[50];
			itoa(counter, temp, 10);
			strcat(tempArr, temp);
			if(counter==10)
				Sleep(1000);
			if ((lobuf = sendto(cC, /*tempArr*/obuf, strlen(/*tempArr*/obuf) + 1, NULL,(sockaddr*)&serv, sizeof(serv))) == SOCKET_ERROR)
				throw  SetErrorMsgText("recv:", WSAGetLastError());
			int lc = sizeof(serv);
			if (libuf = recvfrom(cC, temp, sizeof(temp), NULL, (sockaddr*)&serv, &lc) == SOCKET_ERROR)
				throw  SetErrorMsgText("recv:", WSAGetLastError());
			cout << temp << endl;
			counter--;
		} while (counter > 0);
		
		if ((lobuf = sendto(cC, "", strlen("") + 1, NULL, (sockaddr*)&serv, sizeof(serv))) == SOCKET_ERROR)
			throw  SetErrorMsgText("recv:", WSAGetLastError());

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
