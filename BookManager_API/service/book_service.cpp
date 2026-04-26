#include "book_service.h"

BookService::BookService(IBookRepo &repo) : repo(repo) {}
BookService::~BookService() = default;

void BookService::createBook(const Book &book) {
    if (book.getTitle().empty() || book.getAuthor().empty()) {
        throw std::runtime_error("Invalid book data. Title/author cannot be empty.");
    }

    const auto &books = repo.getBooks();
    auto it = std::find_if(books.begin(), books.end(), [&book](const Book &b) {
        return b.getId() == book.getId();
    });

    if (it != books.end()) {
        throw std::runtime_error("A book with the same ID already exists.");
    }

    repo.addBook(book);
}

std::vector<Book> BookService::listAllBooks() {
    return repo.getBooks();
}

void BookService::updateBook(const Book &book) {
    if (book.getId() <= 0 || book.getTitle().empty() || book.getAuthor().empty()) {
        throw std::runtime_error("Invalid book data. ID must be positive and title/author cannot be empty.");
    }

    repo.updateBook(book);
}

void BookService::deleteBook(int id) {
    if (id <= 0) {
        throw std::runtime_error("Invalid book ID. ID must be positive.");
    }

    std::vector<Book> books = repo.getBooks();
    auto it = std::find_if(books.begin(), books.end(), [id](const Book &b) {
        return b.getId() == id;
    });

    if (it == books.end()) {
        throw std::runtime_error("No book found with the given ID.");
    }

    repo.deleteBook(id);
}

Book BookService::getBookById(int id) {
    if (id <= 0 || id > repo.getBooks().size()) {
        throw std::runtime_error("Invalid book ID. ID must be positive.");
    }

    return repo.getBookById(id);
}