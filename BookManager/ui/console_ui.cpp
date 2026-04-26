#include "console_ui.h"

#include <iostream>

ConsoleUI::ConsoleUI(IBookService& bs,
                     IMemberService& ms,
                     IBorrowRecordService& brs)
    : bookService(bs), memberService(ms), borrowRecordService(brs) {}

void ConsoleUI::run() {
    int choice;

    do {
        printMenu();
        std::cin >> choice;

        switch (choice) {
            case 1: handleBooks(); break;
            case 2: handleMembers(); break;
            case 3: handleBorrowing(); break;
            case 0: std::cout << "Exiting...\n"; break;
            default: std::cout << "Invalid option\n";
        }

    } while (choice != 0);
}

void ConsoleUI::printMenu() {
    std::cout << "\n===== LIBRARY SYSTEM =====\n";
    std::cout << "1. Books\n";
    std::cout << "2. Members\n";
    std::cout << "3. Borrowing\n";
    std::cout << "0. Exit\n";
    std::cout << "Choice: ";
}

void ConsoleUI::handleBooks() {
    int choice;
    do {
        std::cout << "\n--- BOOK MENU ---\n";
        std::cout << "1. Add Book\n";
        std::cout << "2. List Books\n";
        std::cout << "3. Delete Book\n";
        std::cout << "4. Get Book By Id\n";
        std::cout << "0. Back\n";
        std::cout << "Choice: ";
        std::cin >> choice;

        std::cin.ignore();

        if (choice == 1) {
            std::string title, author;
            bool isAvailable;

            std::cout << "Title: ";
            std::getline(std::cin, title);

            std::cout << "Author: ";
            std::getline(std::cin, author);

            std::cout << "Is Available (1/0): ";
            std::cin >> isAvailable;
            std::cin.ignore();

            try {
                Book book(title, author, isAvailable);
                bookService.createBook(book);
                std::cout << "Book added successfully.\n";
            } catch (const std::exception& e) {
                std::cout << e.what() << "\n";
            }
        }
        else if (choice == 2) {
            auto books = bookService.listAllBooks();
            std::cout << "\n--- BOOKS LIST ---\n";
            for (const auto& b : books) {
                std::cout << "ID: " << b.getId()
                          << " | Title: " << b.getTitle()
                          << " | Author: " << b.getAuthor()
                          << " | Status: " << (b.getIsAvailable() ? "Available" : "Not Available") << "\n";
            }
        }
        else if (choice == 3) {
            int id;
            std::cout << "ID: ";
            std::cin >> id;
            std::cin.ignore();

            try {
                bookService.deleteBook(id);
                std::cout << "Deleted successfully.\n";
            } catch (const std::exception& e) {
                std::cout << e.what() << "\n";
            }
        }
        else if (choice == 4) {
            int id;
            std::cout << "ID: ";
            std::cin >> id;
            std::cin.ignore();

            try {
                Book b = bookService.getBookById(id);
                std::cout << "--- BOOK FOUND ---\n";
                std::cout << "ID: " << b.getId()
                          << " | Title: " << b.getTitle()
                          << " | Author: " << b.getAuthor()
                          << " | Status: " << (b.getIsAvailable() ? "Available" : "Not Available") << "\n";
            } catch (const std::exception& e) {
                std::cout << e.what() << "\n";
            }
        }
        else if (choice != 0) {
            std::cout << "Invalid option\n";
        }
    } while (choice != 0);
}

void ConsoleUI::handleMembers() {
    int choice;
    do {
        std::cout << "\n--- MEMBER MENU ---\n";
        std::cout << "1. Add Member\n";
        std::cout << "2. List Members\n";
        std::cout << "3. Delete Member\n";
        std::cout << "4. Get Member By Id\n";
        std::cout << "0. Back\n";
        std::cout << "Choice: ";
        std::cin >> choice;

        std::cin.ignore();

        if (choice == 1) {
            std::string name;

            std::cout << "Name: ";
            std::getline(std::cin, name);

            try {
                Member m(name);
                memberService.createMember(m);
                std::cout << "Member added.\n";
            } catch (const std::exception& e) {
                std::cout << e.what() << "\n";
            }
        }
        else if (choice == 2) {
            auto members = memberService.listAllMembers();
            std::cout << "\n--- MEMBERS LIST ---\n";
            for (const auto& m : members) {
                std::cout << "ID: " << m.getId()
                          << " | Name: " << m.getName() << "\n";
            }
        }
        else if (choice == 3) {
            int id;
            std::cout << "ID: ";
            std::cin >> id;
            std::cin.ignore();

            try {
                memberService.deleteMember(id);
                std::cout << "Deleted.\n";
            } catch (const std::exception& e) {
                std::cout << e.what() << "\n";
            }
        }
        else if (choice == 4) {
            int id;
            std::cout << "ID: ";
            std::cin >> id;
            std::cin.ignore();

            try {
                Member m = memberService.getMemberById(id);
                std::cout << "--- MEMBER FOUND ---\n";
                std::cout << "ID: " << m.getId()
                          << " | Name: " << m.getName() << "\n";
            } catch (const std::exception& e) {
                std::cout << e.what() << "\n";
            }
        }
        else if (choice != 0) {
            std::cout << "Invalid option\n";
        }
    } while (choice != 0);
}

void ConsoleUI::handleBorrowing() {
    int choice;
    do {
        std::cout << "\n--- BORROW MENU ---\n";
        std::cout << "1. Borrow Book\n";
        std::cout << "2. List Borrowed Books\n";
        std::cout << "3. Return Book\n";
        std::cout << "4. Get Borrowed Book By Id\n";
        std::cout << "0. Back\n";
        std::cout << "Choice: ";
        std::cin >> choice;

        std::cin.ignore();

        if (choice == 1) {
            int bookId, memberId;
            std::string date;

            std::cout << "Book ID: ";
            std::cin >> bookId;

            std::cout << "Member ID: ";
            std::cin >> memberId;

            std::cin.ignore();
            std::cout << "Date: ";
            std::getline(std::cin, date);

            try {
                BorrowRecord r(bookId, memberId, date);
                borrowRecordService.borrowBook(r);
                std::cout << "Borrowed successfully.\n";
            } catch (const std::exception& e) {
                std::cout << e.what() << "\n";
            }
        }
        else if (choice == 2) {
            auto records = borrowRecordService.listBorrowedBooks();
            auto books = bookService.listAllBooks();
            auto members = memberService.listAllMembers();

            std::cout << "\n--- BORROWED BOOKS LIST ---\n";
            for (const auto& r : records) {
                std::string bookTitle = "Unknown Book";
                std::string memberName = "Unknown Member";

                for (const auto& b : books) {
                    if (b.getId() == r.getBookId()) {
                        bookTitle = b.getTitle();
                        break;
                    }
                }

                for (const auto& m : members) {
                    if (m.getId() == r.getMemberId()) {
                        memberName = m.getName();
                        break;
                    }
                }

                std::cout << "Record ID: " << r.getId()
                          << " | Book: " << bookTitle
                          << " | Member: " << memberName
                          << " | Date: " << r.getBorrowDate() << "\n";
            }
        }
        else if (choice == 3) {
            int id;
            std::cout << "Record ID: ";
            std::cin >> id;
            std::cin.ignore();

            try {
                borrowRecordService.returnBook(id);
                std::cout << "Returned successfully.\n";
            } catch (const std::exception& e) {
                std::cout << e.what() << "\n";
            }
        }
        else if (choice == 4) {
            int id;
            std::cout << "Record ID: ";
            std::cin >> id;
            std::cin.ignore();

            try {
                BorrowRecord r = borrowRecordService.getRecordById(id);
                Book b = bookService.getBookById(r.getBookId());
                Member m = memberService.getMemberById(r.getMemberId());

                std::cout << "--- BORROW RECORD FOUND ---\n";
                std::cout << "Record ID: " << r.getId()
                          << " | Book: " << b.getTitle()
                          << " | Member: " << m.getName()
                          << " | Date: " << r.getBorrowDate() << "\n";
            } catch (const std::exception& e) {
                std::cout << e.what() << "\n";
            }
        }
        else if (choice != 0) {
            std::cout << "Invalid option\n";
        }
    } while (choice != 0);
}