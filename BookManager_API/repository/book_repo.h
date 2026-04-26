#pragma once

#include <vector>

#include "i_book_repo.h"
#include "../domain/book.h"
#include "../db/database_manager.h"

class BookRepo : public IBookRepo {
private:
    Database &db;

public:
    BookRepo(Database &db);
    ~BookRepo();

    void addBook(const Book &book) override;
    std::vector<Book> getBooks() override;
    void updateBook(const Book &book) override;
    void deleteBook(int id) override;
    Book getBookById(int id) override;
};
