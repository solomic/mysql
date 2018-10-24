CREATE TABLE `audit` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `tbl` varchar(45) DEFAULT NULL,
  `clmn` varchar(45) DEFAULT NULL,
  `old_value` varchar(2000) DEFAULT NULL,
  `new_value` varchar(2000) DEFAULT NULL,
  `updated_by` varchar(45) DEFAULT NULL,
  `updated` datetime DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci