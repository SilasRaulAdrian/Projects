#pragma once

class Entity {
protected:
    int id;

public:
    Entity();
    Entity(int id);
    ~Entity();
    int getId() const;
    void setId(int newId);
    bool operator==(const Entity &other) const;
};