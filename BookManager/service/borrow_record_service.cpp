#include "borrow_record_service.h"

#include <algorithm>

BorrowRecordService::BorrowRecordService(IBorrowRecordRepo &repo, IBookRepo &bookRepo) :
    repo(repo), bookRepo(bookRepo) {}
BorrowRecordService::~BorrowRecordService() = default;

void BorrowRecordService::borrowBook(const BorrowRecord &record) {
    if (record.getBookId() <= 0 || record.getMemberId() <= 0 || record.getBorrowDate().empty()) {
        throw std::runtime_error("Invalid borrow record data. Book ID, Member ID must be positive and Borrow Date cannot be empty.");
    }

    std::vector<BorrowRecord> records = repo.getBorrowRecords();
    auto it = std::find_if(records.begin(), records.end(), [&record](const BorrowRecord &r) {
        return r.getId() == record.getId();
    });

    if (it != records.end()) {
        throw std::runtime_error("A borrow record with the same ID already exists.");
    }

    Book book = bookRepo.getBookById(record.getBookId());
    if (!book.getIsAvailable()) {
        throw std::runtime_error("The book is currently not available for borrowing.");
    }

    book.setIsAvailable(false);
    bookRepo.updateBook(book);

    repo.addBorrowRecord(record);
}

std::vector<BorrowRecord> BorrowRecordService::listBorrowedBooks() {
    return repo.getBorrowRecords();
}

void BorrowRecordService::returnBook(int recordId) {
    if (recordId <= 0) {
        throw std::runtime_error("Invalid record ID. It must be a positive integer.");
    }

    std::vector<BorrowRecord> records = repo.getBorrowRecords();
    auto it = std::find_if(records.begin(), records.end(), [recordId](const BorrowRecord &r) {
        return r.getId() == recordId;
    });

    if (it == records.end()) {
        throw std::runtime_error("No borrow record found with the given ID.");
    }

    BorrowRecord record = repo.getRecordById(recordId);
    Book book = bookRepo.getBookById(record.getBookId());
    book.setIsAvailable(true);
    bookRepo.updateBook(book);

    repo.deleteBorrowRecord(recordId);
}

BorrowRecord BorrowRecordService::getRecordById(int id) {
    if (id <= 0 || id > repo.getBorrowRecords().size()) {
        throw std::runtime_error("Invalid borrow record ID.");
    }

    return repo.getRecordById(id);
}
