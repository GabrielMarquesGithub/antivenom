START TRANSACTION;

DROP TABLE IF EXISTS city;

CREATE TABLE cities (
    id INT AUTO_INCREMENT PRIMARY KEY, 
    name VARCHAR(255) NOT NULL,       
    country VARCHAR(255) NOT NULL,     
    state VARCHAR(255), -- Alguns países não possuem estados
    population INT UNSIGNED,       
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP, 
    updated_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP 
) ENGINE=InnoDB;

COMMIT;

