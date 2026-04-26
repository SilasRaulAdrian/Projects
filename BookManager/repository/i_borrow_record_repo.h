#pragma once

#include "../domain/borrow_record.h"
#include "../domain/book.h"

#include <vector>

class IBorrowRecordRepo {
public:
    ~IBorrowRecordRepo() = default;

    virtual void addBorrowRecord(const BorrowRecord &record) = 0;
    virtual std::vector<BorrowRecord> getBorrowRecords() = 0;
    virtual void deleteBorrowRecord(int id) = 0;
    virtual BorrowRecord getRecordById(int id) = 0;
};