create schema TelegramBot;


create table  "telegrambot".user (
                                     id serial primary key,
                                     client_id bigint ,
                                     password varchar(20),
                                     phone_number varchar(20)
);




create table "telegrambot".Client (
                                      id serial primary key ,
                                      user_id bigint  REFERENCES "telegrambot".user(id),
                                      chat_id int,
                                      nickName varchar(20),
                                      isPremium bool,
                                      status int,
                                      clientInAnonymChat bool
);





create table "telegrambot".Board (
                                     id serial primary key ,
                                     owner_id bigint references "telegrambot".Client(id),
                                     nickName varchar(20),
                                     to_id bigint REFERENCES "telegrambot".Client(id))
    );


create table "telegrambot".AnonyChat(
                                        id serial primary key ,
                                        client_id int,
                                        status int,
                                        create_time timestamp ,
                                        from_id bigint REFERENCES "telegrambot".Client(id),
                                        to_id bigint REFERENCES "telegrambot".Client(id)
);

create table "telegrambot".Message(
                                      id int ,
                                      message varchar(200),
                                      from_id int REFERENCES "telegrambot".Client(id),
                                      chat_id bigint REFERENCES "telegrambot".AnonyChat(id)
                                          board_id int,

);
