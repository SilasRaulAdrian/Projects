#pragma once

#include "i_borrow_record_service.h"
#include "../repository/i_book_repo.h"
#include "../repository/i_borrow_record_repo.h"

class BorrowRecordService : public IBorrowRecordService {
private:
    IBorrowRecordRepo &repo;
    IBookRepo &bookRepo;

public:
    BorrowRecordService(IBorrowRecordRepo &repo, IBookRepo &bookRepo);
    ~BorrowRecordService();

    void borrowBook(const BorrowRecord &record) override;
    void returnBook(int recordId) override;
    std::vector<BorrowRecord> listBorrowedBooks() override;
    BorrowRecord getRecordById(int id) override;
};
