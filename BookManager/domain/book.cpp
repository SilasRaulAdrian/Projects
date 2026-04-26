#include "book.h"

#include <iostream>

Book::Book() = default;

Book::Book(int id, const std::string &title, const std::string &author, bool isAvailable)
    : Entity(id), title(title), author(author), isAvailable(isAvailable) {}

Book::Book(const std::string &title, const std::string &author, bool isAvailable)
    : title(title), author(author), isAvailable(isAvailable) {}

Book::Book(const Book &other)
    : Entity(other.id), title(other.title), author(other.author), isAvailable(other.isAvailable) {
    std::cout << "Book copy constructor" << std::endl;
}

Book::Book(Book &&other) noexcept
    : Entity(other.id), title(std::move(other.title)), author(std::move(other.author)), isAvailable(other.isAvailable) {
    std::cout << "Book move constructor" << std::endl;
}

Book::~Book() = default;

int Book::getId() const {
    return id;
}

const std::string &Book::getTitle() const {
    return title;
}

const std::string &Book::getAuthor() const {
    return author;
}

bool Book::getIsAvailable() const {
    return isAvailable;
}

void Book::setTitle(const std::string &newTitle) {
    title = newTitle;
}

void Book::setAuthor(const std::string &newAuthor) {
    author = newAuthor;
}

void Book::setIsAvailable(bool newIsAvailable) {
    isAvailable = newIsAvailable;
}
