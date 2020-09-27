#pragma once

#include <QtWidgets/QMainWindow>
#include "ui_ClientOS.h"

class ClientOS : public QMainWindow
{
    Q_OBJECT

public:
    ClientOS(QWidget *parent = Q_NULLPTR);

private:
    Ui::ClientOSClass ui;

    void fromDB();
};
