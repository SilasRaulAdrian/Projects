#include <crow.h>

#include "db/database_manager.h"

#include "repository/book_repo.h"
#include "repository/member_repo.h"
#include "repository/borrow_record_repo.h"

#include "service/book_service.h"
#include "service/member_service.h"
#include "service/borrow_record_service.h"

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

        crow::SimpleApp app;

        // BOOKS

        CROW_ROUTE(app, "/books").methods("GET"_method)
        ([&]() {
            crow::json::wvalue res;
            auto books = bookService.listAllBooks();
            int i = 0;
            for (const auto& b : books) {
                res[i]["id"] = b.getId();
                res[i]["title"] = b.getTitle();
                res[i]["author"] = b.getAuthor();
                res[i]["is_available"] = b.getIsAvailable();
                i++;
            }
            return crow::response(res);
        });

        CROW_ROUTE(app, "/books/<int>").methods("GET"_method)
        ([&](int id) {
           try {
               auto b = bookService.getBookById(id);
               crow::json::wvalue res;
               res["id"] = b.getId();
               res["title"] = b.getTitle();
               res["author"] = b.getAuthor();
               res["is_available"] = b.getIsAvailable();
               return crow::response(res);
           } catch (const std::exception& e) {
               return crow::response(404, e.what());
           }
        });

        CROW_ROUTE(app, "/books").methods("POST"_method)
        ([&](const crow::request& req) {
            auto body = crow::json::load(req.body);
            if (!body) return crow::response(400, "Invalid JSON");

            try {
                Book book(
                    body["title"].s(),
                    body["author"].s(),
                    body["is_available"].b()
                );
                bookService.createBook(book);
                return crow::response(201, "Book created successfully");
            } catch (const std::exception& e) {
                return crow::response(400, e.what());
            }
        });

        CROW_ROUTE(app, "/books/<int>").methods("DELETE"_method)
        ([&](int id) {
            try {
                bookService.deleteBook(id);
                return crow::response(200, "Book deleted successfully");
            } catch (const std::exception& e) {
                return crow::response(404, e.what());
            }
        });

        // MEMBERS

        CROW_ROUTE(app, "/members").methods("GET"_method)
        ([&]() {
            crow::json::wvalue res;
            auto members = memberService.listAllMembers();
            int i = 0;
            for (const auto& m : members) {
                res[i]["id"]   = m.getId();
                res[i]["name"] = m.getName();
                i++;
            }
            return crow::response(res);
        });

        CROW_ROUTE(app, "/members/<int>").methods("GET"_method)
        ([&](int id) {
            try {
                auto m = memberService.getMemberById(id);
                crow::json::wvalue res;
                res["id"]   = m.getId();
                res["name"] = m.getName();
                return crow::response(res);
            } catch (const std::exception& e) {
                return crow::response(404, e.what());
            }
        });

        CROW_ROUTE(app, "/members").methods("POST"_method)
        ([&](const crow::request& req) {
            auto body = crow::json::load(req.body);
            if (!body) return crow::response(400, "Invalid JSON");

            try {
                Member member(body["name"].s());
                memberService.createMember(member);
                return crow::response(201, "Member created");
            } catch (const std::exception& e) {
                return crow::response(400, e.what());
            }
        });

        CROW_ROUTE(app, "/members/<int>").methods("DELETE"_method)
        ([&](int id) {
            try {
                memberService.deleteMember(id);
                return crow::response(200, "Deleted");
            } catch (const std::exception& e) {
                return crow::response(404, e.what());
            }
        });

        // BORROW RECORDS

        CROW_ROUTE(app, "/borrow").methods("GET"_method)
        ([&]() {
            crow::json::wvalue res;
            auto records = borrowService.listBorrowedBooks();
            int i = 0;
            for (const auto& r : records) {
                res[i]["id"]         = r.getId();
                res[i]["bookId"]     = r.getBookId();
                res[i]["memberId"]   = r.getMemberId();
                res[i]["borrowDate"] = r.getBorrowDate();
                i++;
            }
            return crow::response(res);
        });

        CROW_ROUTE(app, "/borrow").methods("POST"_method)
        ([&](const crow::request& req) {
            auto body = crow::json::load(req.body);
            if (!body) return crow::response(400, "Invalid JSON");

            try {
                BorrowRecord record(
                    body["bookId"].i(),
                    body["memberId"].i(),
                    body["borrowDate"].s()
                );
                borrowService.borrowBook(record);
                return crow::response(201, "Borrowed successfully");
            } catch (const std::exception& e) {
                return crow::response(400, e.what());
            }
        });

        CROW_ROUTE(app, "/borrow/<int>/return").methods("PUT"_method)
        ([&](int id) {
            try {
                borrowService.returnBook(id);
                return crow::response(200, "Returned successfully");
            } catch (const std::exception& e) {
                return crow::response(404, e.what());
            }
        });

        app.port(8080).multithreaded().run();

        db.disconnect();

    } catch (const std::exception& e) {
        std::cerr << "Fatal error: " << e.what() << std::endl;
        return 1;
    }

    return 0;
}