#pragma once

#include "../domain/book.h"

#include <vector>

class IBookRepo {
public:
    virtual ~IBookRepo() = default;

    virtual void addBook(const Book &book) = 0;
    virtual std::vector<Book> getBooks() = 0;
    virtual void updateBook(const Book &book) = 0;
    virtual void deleteBook(int id) = 0;
    virtual Book getBookById(int id) = 0;
};