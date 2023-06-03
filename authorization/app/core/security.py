from jose import jwt
from passlib.context import CryptContext
from datetime import timedelta, datetime
pwd_context = CryptContext(schemes=['bcrypt'], deprecated='auto')

ALGORITHM = "HS256"


def create_access_token(subject, expires_delta: timedelta = None):
    if expires_delta:
        expire = datetime.utcnow() + expires_delta
    else:
        expire = datetime.utcnow() + timedelta(days=1)
    to_encode = {"exp": expire, "sub": str(subject)}
    encode_jwt = jwt.encode(to_encode, 'fafafafaf', algorithm=ALGORITHM)
    return encode_jwt


def verify_password(plain_password: str, hashed_password: str) -> bool:
    return pwd_context.verify(plain_password, hashed_password)


def get_password_hash(password: str) -> str:
    return pwd_context.hash(password)
