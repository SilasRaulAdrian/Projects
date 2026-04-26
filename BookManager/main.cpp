#include "db/database_manager.h"

#include "repository/book_repo.h"
#include "repository/member_repo.h"
#include "repository/borrow_record_repo.h"

#include "service/book_service.h"
#include "service/member_service.h"
#include "service/borrow_record_service.h"

#include "ui/console_ui.h"

#include <iostream>

int main() {
    try {
        Database db(
            "host=localhost port=5432 dbname=book_manager_db user=postgres password=root"
        );

        if (!db.connect()) {
            std::cerr << "Failed to connect to database\n";
            return 1;
        }

        std::cout << "Database connection successful!\n";

        BookRepo bookRepo(db);
        MemberRepo memberRepo(db);
        BorrowRecordRepo borrowRepo(db);

        BookService bookService(bookRepo);
        MemberService memberService(memberRepo);
        BorrowRecordService borrowService(borrowRepo, bookRepo);

        ConsoleUI ui(bookService, memberService, borrowService);

        ui.run();

        db.disconnect();

    } catch (const std::exception& e) {
        std::cerr << "Fatal error: " << e.what() << std::endl;
        return 1;
    }

    return 0;
}