#pragma once

#include "../repository/book_repo.h"

class IBookService {
public:
    ~IBookService() = default;

    virtual void createBook(const Book &book) = 0;
    virtual std::vector<Book> listAllBooks() = 0;
    virtual void updateBook(const Book &book) = 0;
    virtual void deleteBook(int id) = 0;
    virtual Book getBookById(int id) = 0;
};