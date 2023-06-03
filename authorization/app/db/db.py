from mongoengine import connect, disconnect
from app.models.user import User
connection = 'mongodb+srv://Aleksey:pass123@cluster0.v0ixh.mongodb.net/HellWeek?retryWrites=true&w=majority'


def connect_to_database():
    connect(host=connection)


def disconnect_from_database():
    disconnect()
