#pragma once

#include "i_book_service.h"

class BookService : public IBookService {
private:
    IBookRepo &repo;

public:
    BookService(IBookRepo &repo);
    ~BookService();

    void createBook(const Book &book) override;
    std::vector<Book> listAllBooks() override;
    void updateBook(const Book &book) override;
    void deleteBook(int id) override;
    Book getBookById(int id) override;
};