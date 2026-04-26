#pragma once

#include "../domain/borrow_record.h"
#include "../domain/book.h"

#include <vector>

class IBorrowRecordService {
public:
    ~IBorrowRecordService() = default;

    virtual void borrowBook(const BorrowRecord &record) = 0;
    virtual void returnBook(int recordId) = 0;
    virtual std::vector<BorrowRecord> listBorrowedBooks() = 0;
    virtual BorrowRecord getRecordById(int id) = 0;
};