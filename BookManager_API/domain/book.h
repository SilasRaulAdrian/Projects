#pragma once

#include <iostream>
#include <string>

#include "entity.h"

class Book : public Entity {
private:
    std::string title;
    std::string author;
    bool isAvailable;
public:
    Book();
    Book(int id, const std::string &title, const std::string &author, bool isAvailable);
    Book(const std::string &title, const std::string &author, bool isAvailable);
    Book(const Book &other);
    Book(Book &&other) noexcept;
    ~Book();
    int getId() const;
    const std::string &getTitle() const;
    const std::string &getAuthor() const;
    bool getIsAvailable() const;
    void setTitle(const std::string &newTitle);
    void setAuthor(const std::string &newAuthor);
    void setIsAvailable(bool newIsAvailable);
};
