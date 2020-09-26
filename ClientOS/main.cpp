#include "ClientOS.h"
#include <QtWidgets/QApplication>

int main(int argc, char *argv[])
{
    QApplication a(argc, argv);
    ClientOS w;
    w.show();
    return a.exec();
}
