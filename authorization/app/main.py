from fastapi import FastAPI

from app.db.db import connect_to_database, disconnect_from_database
from app.api.endpoints import users, auth

app = FastAPI()


@app.on_event('startup')
def startup():
    connect_to_database()


@app.on_event('shutdown')
def shutdown():
    disconnect_from_database()


app.include_router(auth.router, prefix='/users', tags=['users'])

