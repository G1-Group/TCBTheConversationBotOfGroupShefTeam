create schema if not exists TelegramBot;


create table if not exists  "telegrambot".user (
    id bigserial primary key,
    client_id bigint ,
    password varchar(20),
    phone_number varchar(20)
    );




create table if not exists "telegrambot".Client (
    id bigserial primary key ,
    user_id bigint  REFERENCES "telegrambot".user(id),
    chat_id bigint,
    nickName varchar(20),
    isPremium bool,
    status int,
    client_in_anonymChat bool
    );



create table if not exists "telegrambot".Board (
    id bigserial primary key ,
    owner_id bigint references "telegrambot".Client(id),
    nickName varchar(20)
    );


create table if not exists "telegrambot".AnonyChat(
    id bigserial primary key ,
    status int,
    create_time date ,
    from_id bigint REFERENCES "telegrambot".Client(id),
    to_id bigint REFERENCES "telegrambot".Client(id)
    );

create table if not exists "telegrambot".Message(
    id bigserial primary key ,
    message varchar(200),
    from_id bigint,
    time date,
    chat_id bigint ,
    board_id bigint,
    message_status int,
    status int
    );


