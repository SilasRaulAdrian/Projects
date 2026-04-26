#include "entity.h"

Entity::Entity() = default;
Entity::Entity(int id) : id(id) {}
Entity::~Entity() = default;

int Entity::getId() const {
    return id;
}

void Entity::setId(int newId) {
    id = newId;
}