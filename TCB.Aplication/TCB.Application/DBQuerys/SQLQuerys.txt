create table users(id serial primary key,telegram_client_id bigint,phone_number varchar(13),password varchar(16));

create table clients(client_id serial primary key, user_id bigint REFERENCES Users(id),
first_name varchar(30),user_name varchar(30),nickname varchar(20),status int,isPremium bool);

create table anonym_chats (chat_id serial primary key,state int,created_date timestamp,from_id bigint REFERENCES clients(client_id),
to_id bigint REFERENCES clients(client_id));


create table boards(board_id serial primary key,nickname varchar(15), owner_id bigint references clients(client_id));

create table messages(id serial primary key,from_id bigint REFERENCES clients(client_id),message varchar(400),
chat_id bigint REFERENCES anonym_chats(chat_id),
board_id bigint REFERENCES boards(board_id),message_type int);

create table logs(id serial primary key,from_id bigint,to_id bigint,action varchar(100));