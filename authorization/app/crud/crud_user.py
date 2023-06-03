from app.models.user import User
from mongoengine import connect, disconnect

from app.core.security import verify_password, get_password_hash

connection = 'mongodb+srv://Aleksey:pass123@cluster0.v0ixh.mongodb.net/HellWeek?retryWrites=true&w=majority'


class CRUDUser:
    def __init__(self, model):
        self.model = model

    def get(self, user_id: str):
        return self.model.objects(id=user_id).first()

    def get_by_email(self, email: str):
        return self.model.objects(email=email).first()

    def get_multi(self, skip: int = 0, limit: int = 10):
        return list(self.model.objects[skip:limit])

    def create(self, user):
        new_user = self.model(
            email=user.email,
            name=user.name,
            password=get_password_hash(user.password),
            birthdate=user.birthdate
        )
        new_user.save()

        return new_user

    def update(self, email: str, new_data: dict):
        user = User.objects(email=email)
        user.update(**new_data)
        return user

    def delete(self, user_id: str):
        user = User.objects(id=user_id)
        user.delete()
        return user

    def authenticate(self, email: str, password: str):
        user = self.get_by_email(email=email)
        if not user:
            return None
        if not verify_password(password, user.password):
            return None
        return user


user = CRUDUser(User)
