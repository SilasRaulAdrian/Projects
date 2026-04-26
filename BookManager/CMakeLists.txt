cmake_minimum_required(VERSION 3.28)
project(BookManager)

set(CMAKE_CXX_STANDARD 20)

find_package(libpqxx REQUIRED)

add_executable(BookManager main.cpp
        db/database_manager.h
        db/database_manager.cpp
        domain/book.h
        domain/entity.h
        domain/entity.cpp
        domain/book.cpp
        domain/member.h
        domain/member.cpp
        domain/borrow_record.h
        domain/borrow_record.cpp
        repository/book_repo.h
        repository/book_repo.cpp
        repository/member_repo.h
        repository/i_book_repo.h
        repository/i_member_repo.h
        repository/member_repo.cpp
        repository/i_borrow_record_repo.h
        repository/borrow_record_repo.h
        repository/borrow_record_repo.cpp
        service/i_book_service.h
        service/book_service.h
        service/book_service.cpp
        service/i_member_service.h
        service/member_service.h
        service/member_service.cpp
        service/i_borrow_record_service.h
        service/borrow_record_service.h
        service/borrow_record_service.cpp
        ui/console_ui.h
        ui/console_ui.cpp
)

target_link_libraries(BookManager PRIVATE libpqxx::pqxx)