#include "member.h"

Member::Member() = default;
Member::Member(int id, const std::string &name) : Entity(id), name(name) {}
Member::Member(const std::string &name) : name(name) {}
Member::Member(const Member &other) : Entity(other.id), name(other.name) {
    std::cout << "Member copy constructor" << std::endl;
}
Member::Member(Member &&other) noexcept : Entity(other.id), name(std::move(other.name)) {
    std::cout << "Member move constructor" << std::endl;
}
Member::~Member() = default;

int Member::getId() const {
    return id;
}

const std::string &Member::getName() const {
    return name;
}

void Member::setName(const std::string &newName) {
    name = newName;
}