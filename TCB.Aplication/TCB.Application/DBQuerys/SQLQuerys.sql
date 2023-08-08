create schema if not exists telegramBot;


create table if not exists  telegrambot.User (
    id bigserial primary key,
    chat_id bigint ,
    password varchar(20),
    phone_number varchar(20)
    );




create table if not exists telegrambot.Client (
    id bigserial primary key ,
    user_id bigint  REFERENCES "telegrambot".user(id),
    chat_id bigint,
    nickName varchar(20),
    isPremium bool,
    status int,
    client_in_anonymChat bool
    );



create table if not exists telegrambot.Board (
    id bigserial primary key ,
    owner_id bigint references "telegrambot".Client(id),
    nickName varchar(20)
    );


create table if not exists telegrambot.AnonyChat(
    id bigserial primary key ,
    anonym_chat_status int,
    time date ,
    client_chat_id_first bigint REFERENCES "telegrambot".Client(id),
    client_chat_id_last bigint REFERENCES "telegrambot".Client(id)
    );
   
create table if not exists telegrambot.Message(
    id bigserial primary key ,
    text varchar(200),
    from_id bigint,
    time date,
    anonym_chat_id bigint ,
    board_id bigint,
    message_status int,
    status int
    );