import datetime

from pydantic import BaseModel, EmailStr


class UserBase(BaseModel):
    email: EmailStr
    name: str
    birthdate: datetime.date


class User(UserBase):
    level: float
    bio: str
    location: str

    class Config:
        orm_mode = True


class UserCreate(UserBase):
    password: str
    repeat_password: str
