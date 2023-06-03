from mongoengine import StringField, EmailField, DateTimeField, IntField, FloatField, Document, DateField
from datetime import datetime


class User(Document):
    name = StringField(max_length=50)
    email = EmailField(required=True, unique=True)
    password = StringField(max_length=255)
    bio = StringField(max_length=255, default="")
    location = StringField(max_length=100, default="")
    birthdate = DateField()
    data_created = DateTimeField(default=datetime.now())
    level = FloatField(default=1)









