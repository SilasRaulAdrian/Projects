#pragma once

#include "../service/i_book_service.h"
#include "../service/i_borrow_record_service.h"
#include "../service/i_member_service.h"

class ConsoleUI {
private:
    IBookService &bookService;
    IMemberService &memberService;
    IBorrowRecordService &borrowRecordService;

public:
    ConsoleUI(IBookService &bs, IMemberService &ms, IBorrowRecordService &brs);

    void printMenu();
    void run();

    void handleBooks();
    void handleMembers();
    void handleBorrowing();
};