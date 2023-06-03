import typing

from fastapi import APIRouter, Response, HTTPException, Depends
from app import crud
from app import schemas
from typing import List
router = APIRouter()


@router.get('/', response_model=List[schemas.User])
async def get_users(
        skip: int = 0,
        limit: int = 20,
):
    users = crud.user.get_multi(skip=skip, limit=limit)
    return users


@router.get('/{user_id}', response_model=schemas.User)
async def get_user(
        user_id: str
):
    user = crud.user.get(user_id)
    return user


@router.post('/register', response_model=schemas.User)
async def create_user(
        new_user: schemas.UserCreate
):
    """
    Create user

    :param new_user:
    :return:
    """
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


@router.delete('/{user_id}')
async def delete_user(
    user_id: str
):
    """
    Deleted User by id
    :param user_id:
    :return:
    """
    user = crud.user.delete(user_id=user_id)
    return {'detail': 'User has been deleted'}

