CREATE TABLE communicator_user(
    id INT PRIMARY KEY IDENTITY (1, 1),
    login VARCHAR(50) UNIQUE NOT NULL,
    password VARCHAR(50) NOT NULL,
    name VARCHAR(30) NOT NULL,
	avatar VARCHAR(100),
	status VARCHAR(20)
);

CREATE TABLE friendship(
    id INT PRIMARY KEY IDENTITY (1, 1),
    friend1 INT NOT NULL,
    friend2 INT NOT NULL,
    FOREIGN KEY (friend1) REFERENCES communicator_user (id),
    FOREIGN KEY (friend2) REFERENCES communicator_user (id)
);

CREATE TABLE message(
    id INT PRIMARY KEY IDENTITY (1, 1),
    from_user_id INT NOT NULL,
    to_user_id INT NOT NULL,
    isread BIT NOT NULL,
	content VARCHAR(500),
	message_type VARCHAR(20),
	content_link VARCHAR(100),
	send_time DATETIME NOT NULL,
    FOREIGN KEY (from_user_id) REFERENCES communicator_user (id),
    FOREIGN KEY (to_user_id) REFERENCES communicator_user (id)
);
