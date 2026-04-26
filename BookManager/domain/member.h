#pragma once

#include <iostream>
#include <string>

#include "entity.h"

class Member : public Entity {
private:
    std::string name;

public:
    Member();
    Member(int id, const std::string &name);
    Member(const std::string &name);
    Member(const Member &other);
    Member(Member &&other) noexcept;
    ~Member();

    int getId() const;
    const std::string &getName() const;
    void setName(const std::string &newName);
};
