#include "borrow_record.h"

BorrowRecord::BorrowRecord() = default;
BorrowRecord::BorrowRecord(int id, int bookId, int memberId, const std::string &borrowDate) :
    Entity(id), bookId(bookId), memberId(memberId), borrowDate(borrowDate) {}
BorrowRecord::BorrowRecord(int bookId, int memberId, const std::string &borrowDate) :
    bookId(bookId), memberId(memberId), borrowDate(borrowDate) {}
BorrowRecord::BorrowRecord(const BorrowRecord &other) :
    Entity(other.id), bookId(other.bookId), memberId(other.memberId), borrowDate(other.borrowDate) {
    std::cout << "BorrowRecord copy constructor" << std::endl;
}
BorrowRecord::BorrowRecord(BorrowRecord &&other) noexcept :
    Entity(other.id), bookId(other.bookId), memberId(other.memberId), borrowDate(std::move(other.borrowDate)) {
    std::cout << "BorrowRecord move constructor" << std::endl;
}
BorrowRecord::~BorrowRecord() = default;

int BorrowRecord::getId() const {
    return id;
}

int BorrowRecord::getBookId() const {
    return bookId;
}

int BorrowRecord::getMemberId() const {
    return memberId;
}

const std::string &BorrowRecord::getBorrowDate() const {
    return borrowDate;
}

void BorrowRecord::setBookId(int newBookId) {
    bookId = newBookId;
}

void BorrowRecord::setMemberId(int newMemberId) {
    memberId = newMemberId;
}

void BorrowRecord::setBorrowDate(const std::string &newBorrowDate) {
    borrowDate = newBorrowDate;
}