import datetime

from fastapi import APIRouter, Response, HTTPException, Depends
from app import crud
from app import schemas
from app.core import security

router = APIRouter()


@router.post('/register', response_model=schemas.User)
async def register(
        new_user: schemas.UserCreate
):
    user = crud.user.get_by_email(email=new_user.email)
    if user:
        raise HTTPException(
            status_code=400,
            detail="The user with this username already exists in the system"
        )
    if new_user.repeat_password == new_user.password:
        user = crud.user.create(new_user)
    else:
        raise HTTPException(
            status_code=400,
            detail="The two password fields didn't match."
        )
    return user


@router.post('/login')
async def login(
        login: schemas.Login
):
    user = crud.user.authenticate(email=login.email, password=login.password)
    if not user:
        raise HTTPException(status_code=400, detail="Incorrect email or password")

    access_token = security.create_access_token(
        user.id, expires_delta=datetime.timedelta(days=1)
    )
    return {
        'access_token': access_token,
        'token_type': 'bearer'
    }
