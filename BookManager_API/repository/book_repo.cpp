#include "book_repo.h"

BookRepo::BookRepo(Database &db) : db(db) {}
BookRepo::~BookRepo() = default;

void BookRepo::addBook(const Book &book) {
    pqxx::connection &conn = db.getConnection();
    pqxx::work txn(conn);

    txn.exec_params(
        "INSERT INTO books (title, author, is_available) VALUES ($1, $2, $3)",
        book.getTitle(),
        book.getAuthor(),
        book.getIsAvailable()
    );

    txn.commit();
}

std::vector<Book> BookRepo::getBooks() {
    pqxx::connection &conn = db.getConnection();
    pqxx::work txn(conn);

    pqxx::result res = txn.exec("SELECT * FROM books");

    std::vector<Book> books;

    for (const auto &row : res) {
        books.emplace_back(
            row["id"].as<int>(),
            row["title"].as<std::string>(),
            row["author"].as<std::string>(),
            row["is_available"].as<bool>()
        );
    }

    txn.commit();
    return books;
}

void BookRepo::updateBook(const Book &book) {
    pqxx::connection &conn = db.getConnection();
    pqxx::work txn(conn);

    txn.exec_params(
        "UPDATE books SET title = $1, author = $2, is_available = $3 WHERE id = $4",
        book.getTitle(),
        book.getAuthor(),
        book.getIsAvailable(),
        book.getId()
    );

    txn.commit();
}

void BookRepo::deleteBook(int id) {
    pqxx::connection &conn = db.getConnection();
    pqxx::work txn(conn);

    txn.exec_params(
        "DELETE FROM books WHERE id = $1",
        id
    );

    txn.commit();
}

Book BookRepo::getBookById(int id) {
    pqxx::connection &conn = db.getConnection();
    pqxx::work txn(conn);

    pqxx::result res = txn.exec_params(
        "SELECT * FROM books WHERE id = $1",
        id
    );

    const auto &row = res[0];
    Book book(
        row["id"].as<int>(),
        row["title"].as<std::string>(),
        row["author"].as<std::string>(),
        row["is_available"].as<bool>()
    );

    txn.commit();
    return book;
}