#include "ClientOS.h"
#include <QtGui>
#include <QtWidgets>

ClientOS::ClientOS(QWidget *parent)
    : QMainWindow(parent)
{
    ui.setupUi(this);
    this->setFixedSize(900,600);

    fromDB();
}

void ClientOS::fromDB()
{
    ui.comboBoxUom->addItem("test");

    QList<QString> dsad;
    dsad << "ex1" << "ex2";
    ui.comboBoxProduct->addItems(dsad);
}
