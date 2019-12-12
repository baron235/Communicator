
CREATE TABLE user_file(
    id INT PRIMARY KEY IDENTITY (1, 1),
	path varchar(100) NOT NULL
);

CREATE TABLE communicator_user(
    login VARCHAR(50) PRIMARY KEY NOT NULL,
    password VARCHAR(50) NOT NULL,
    name VARCHAR(30) NOT NULL,
	avatar INT,
	status VARCHAR(20),
    FOREIGN KEY (avatar) REFERENCES user_file (id)
);

CREATE TABLE friendship(
    id INT PRIMARY KEY IDENTITY (1, 1),
    friend1 VARCHAR(50) NOT NULL,
    friend2 VARCHAR(50) NOT NULL,
    FOREIGN KEY (friend1) REFERENCES communicator_user (login),
    FOREIGN KEY (friend2) REFERENCES communicator_user (login)
);

CREATE TABLE message(
    id INT PRIMARY KEY IDENTITY (1, 1),
    from_user VARCHAR(50) NOT NULL,
    to_user VARCHAR(50) NOT NULL,
    isread BIT NOT NULL,
	content VARCHAR(500),
	message_type INT,
	file_id INT,
	send_time DATETIME NOT NULL,
    FOREIGN KEY (from_user) REFERENCES communicator_user (login),
    FOREIGN KEY (to_user) REFERENCES communicator_user (login),
    FOREIGN KEY (file_id) REFERENCES user_file (id)
);

