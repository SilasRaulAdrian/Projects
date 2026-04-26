#pragma once

#include "i_borrow_record_repo.h"
#include "../domain/borrow_record.h"
#include "../db/database_manager.h"

class BorrowRecordRepo : public IBorrowRecordRepo {
private:
    Database &db;

public:
    BorrowRecordRepo(Database &db);
    ~BorrowRecordRepo();

    void addBorrowRecord(const BorrowRecord &record) override;
    std::vector<BorrowRecord> getBorrowRecords() override;
    void deleteBorrowRecord(int id) override;
    BorrowRecord getRecordById(int id) override;
};