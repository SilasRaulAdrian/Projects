#pragma once

#include <iostream>
#include <string>

#include "entity.h"

class BorrowRecord : public Entity {
private:
    int bookId;
    int memberId;
    std::string borrowDate;

public:
    BorrowRecord();
    BorrowRecord(int id, int bookId, int memberId, const std::string &borrowDate);
    BorrowRecord(int bookId, int memberId, const std::string &borrowDate);
    BorrowRecord(const BorrowRecord &other);
    BorrowRecord(BorrowRecord &&other) noexcept;
    ~BorrowRecord();

    int getId() const;
    int getBookId() const;
    int getMemberId() const;
    const std::string &getBorrowDate() const;
    void setBookId(int newBookId);
    void setMemberId(int newMemberId);
    void setBorrowDate(const std::string &newBorrowDate);
};