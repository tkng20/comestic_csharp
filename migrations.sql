CREATE TABLE IF NOT EXISTS `__EFMigrationsHistory` (
    `MigrationId` varchar(150) NOT NULL,
    `ProductVersion` varchar(32) NOT NULL,
    PRIMARY KEY (`MigrationId`)
);

CREATE TABLE `__efmigrationshistory` (
    `MigrationId` varchar(150) NOT NULL,
    `ProductVersion` varchar(32) NOT NULL,
    PRIMARY KEY (`MigrationId`)
);

CREATE TABLE `banners` (
    `id` bigint(20) unsigned NOT NULL AUTO_INCREMENT,
    `title` varchar(191) NOT NULL,
    `slug` varchar(191) NOT NULL,
    `photo` varchar(191) NULL DEFAULT 'NULL',
    `description` text NULL DEFAULT 'NULL',
    `status` enum('active','inactive') NOT NULL DEFAULT '''inactive''',
    PRIMARY KEY (`id`)
);

CREATE TABLE `brands` (
    `id` bigint(20) unsigned NOT NULL AUTO_INCREMENT,
    `title` varchar(191) NOT NULL,
    `slug` varchar(191) NOT NULL,
    `status` enum('active','inactive') NOT NULL DEFAULT '''active''',
    PRIMARY KEY (`id`)
);

CREATE TABLE `coupons` (
    `id` bigint(20) unsigned NOT NULL AUTO_INCREMENT,
    `code` varchar(191) NOT NULL,
    `type` enum('fixed','percent') NOT NULL DEFAULT '''fixed''',
    `value` decimal(20,2) NOT NULL,
    `status` enum('active','inactive') NOT NULL DEFAULT '''active''',
    `is_voucher` tinyint(1) NOT NULL,
    `quantity` int(11) NOT NULL,
    PRIMARY KEY (`id`)
);

CREATE TABLE `messages` (
    `id` bigint(20) unsigned NOT NULL AUTO_INCREMENT,
    `name` varchar(191) NOT NULL,
    `subject` text NOT NULL,
    `email` varchar(191) NOT NULL,
    `photo` varchar(191) NULL DEFAULT 'NULL',
    `phone` varchar(191) NULL DEFAULT 'NULL',
    `message` longtext NOT NULL,
    PRIMARY KEY (`id`)
);

CREATE TABLE `notifications` (
    `id` char(36) NOT NULL,
    `type` varchar(191) NOT NULL,
    `notifiable_type` varchar(191) NOT NULL,
    `notifiable_id` bigint(20) unsigned NOT NULL,
    `data` text NOT NULL,
    PRIMARY KEY (`id`)
);

CREATE TABLE `password_resets` (
    `email` varchar(191) NOT NULL,
    `token` varchar(191) NOT NULL
);

CREATE TABLE `post_categories` (
    `id` bigint(20) unsigned NOT NULL AUTO_INCREMENT,
    `title` varchar(191) NOT NULL,
    `slug` varchar(191) NOT NULL,
    `status` enum('active','inactive') NOT NULL DEFAULT '''active''',
    PRIMARY KEY (`id`)
);

CREATE TABLE `post_tags` (
    `id` bigint(20) unsigned NOT NULL AUTO_INCREMENT,
    `title` varchar(191) NOT NULL,
    `slug` varchar(191) NOT NULL,
    `status` enum('active','inactive') NOT NULL DEFAULT '''active''',
    PRIMARY KEY (`id`)
);

CREATE TABLE `settings` (
    `id` bigint(20) unsigned NOT NULL AUTO_INCREMENT,
    `description` longtext NOT NULL,
    `short_des` text NOT NULL,
    `logo` varchar(191) NOT NULL,
    `photo` varchar(191) NOT NULL,
    `address` varchar(191) NOT NULL,
    `phone` varchar(191) NOT NULL,
    `email` varchar(191) NOT NULL,
    PRIMARY KEY (`id`)
);

CREATE TABLE `shippings` (
    `id` bigint(20) unsigned NOT NULL AUTO_INCREMENT,
    `type` varchar(191) NOT NULL,
    `price` decimal(8,2) NOT NULL,
    `status` enum('active','inactive') NOT NULL DEFAULT '''active''',
    PRIMARY KEY (`id`)
);

CREATE TABLE `users` (
    `id` bigint(20) unsigned NOT NULL AUTO_INCREMENT,
    `name` varchar(191) NOT NULL,
    `email` varchar(191) NULL DEFAULT 'NULL',
    `password` varchar(191) NULL DEFAULT 'NULL',
    `photo` varchar(191) NULL DEFAULT 'NULL',
    `role` enum('admin','user') NOT NULL DEFAULT '''user''',
    `provider` varchar(191) NULL DEFAULT 'NULL',
    `provider_id` varchar(191) NULL DEFAULT 'NULL',
    `status` enum('active','inactive') NOT NULL DEFAULT '''active''',
    `remember_token` varchar(100) NULL DEFAULT 'NULL',
    PRIMARY KEY (`id`)
);

CREATE TABLE `categories` (
    `id` bigint(20) unsigned NOT NULL AUTO_INCREMENT,
    `title` varchar(191) NOT NULL,
    `slug` varchar(191) NOT NULL,
    `summary` text NULL DEFAULT 'NULL',
    `photo` varchar(191) NULL DEFAULT 'NULL',
    `is_parent` tinyint(1) NOT NULL DEFAULT '1',
    `parent_id` bigint(20) unsigned NULL DEFAULT 'NULL',
    `added_by` bigint(20) unsigned NULL DEFAULT 'NULL',
    `status` enum('active','inactive') NOT NULL DEFAULT '''inactive''',
    PRIMARY KEY (`id`),
    CONSTRAINT `categories_added_by_foreign` FOREIGN KEY (`added_by`) REFERENCES `users` (`id`) ON DELETE SET NULL,
    CONSTRAINT `categories_parent_id_foreign` FOREIGN KEY (`parent_id`) REFERENCES `categories` (`id`) ON DELETE SET NULL
);

CREATE TABLE `orders` (
    `id` bigint(20) unsigned NOT NULL AUTO_INCREMENT,
    `order_number` varchar(191) NOT NULL,
    `user_id` bigint(20) unsigned NULL DEFAULT 'NULL',
    `sub_total` decimal(10,0) NOT NULL,
    `shipping_id` bigint(20) unsigned NULL DEFAULT 'NULL',
    `coupon_id` bigint(20) unsigned NULL DEFAULT 'NULL',
    `total_amount` decimal(10,0) NOT NULL,
    `quantity` int(11) NOT NULL,
    `payment_method` enum('cod','paypal') NOT NULL DEFAULT '''cod''',
    `payment_status` enum('paid','unpaid') NOT NULL DEFAULT '''unpaid''',
    `status` enum('new','process','delivered','cancel') NOT NULL DEFAULT '''new''',
    `first_name` varchar(191) NOT NULL,
    `last_name` varchar(191) NOT NULL,
    `email` varchar(191) NOT NULL,
    `phone` varchar(191) NOT NULL,
    `country` varchar(191) NOT NULL,
    `address` text NOT NULL,
    PRIMARY KEY (`id`),
    CONSTRAINT `orders_coupon_id_foreign` FOREIGN KEY (`coupon_id`) REFERENCES `coupons` (`id`) ON DELETE SET NULL,
    CONSTRAINT `orders_shipping_id_foreign` FOREIGN KEY (`shipping_id`) REFERENCES `shippings` (`id`) ON DELETE SET NULL,
    CONSTRAINT `orders_user_id_foreign` FOREIGN KEY (`user_id`) REFERENCES `users` (`id`) ON DELETE SET NULL
);

CREATE TABLE `posts` (
    `id` bigint(20) unsigned NOT NULL AUTO_INCREMENT,
    `title` varchar(191) NOT NULL,
    `slug` varchar(191) NOT NULL,
    `summary` text NOT NULL,
    `description` longtext NULL DEFAULT 'NULL',
    `quote` text NULL DEFAULT 'NULL',
    `photo` varchar(191) NULL DEFAULT 'NULL',
    `tags` varchar(191) NULL DEFAULT 'NULL',
    `post_cat_id` bigint(20) unsigned NULL DEFAULT 'NULL',
    `post_tag_id` bigint(20) unsigned NULL DEFAULT 'NULL',
    `added_by` bigint(20) unsigned NULL DEFAULT 'NULL',
    `status` enum('active','inactive') NOT NULL DEFAULT '''active''',
    PRIMARY KEY (`id`),
    CONSTRAINT `posts_added_by_foreign` FOREIGN KEY (`added_by`) REFERENCES `users` (`id`) ON DELETE SET NULL,
    CONSTRAINT `posts_post_cat_id_foreign` FOREIGN KEY (`post_cat_id`) REFERENCES `post_categories` (`id`) ON DELETE SET NULL,
    CONSTRAINT `posts_post_tag_id_foreign` FOREIGN KEY (`post_tag_id`) REFERENCES `post_tags` (`id`) ON DELETE SET NULL
);

CREATE TABLE `products` (
    `id` bigint(20) unsigned NOT NULL AUTO_INCREMENT,
    `title` varchar(191) NOT NULL,
    `slug` varchar(191) NOT NULL,
    `summary` text NOT NULL,
    `description` longtext NULL DEFAULT 'NULL',
    `photo1` text NOT NULL,
    `photo2` text NOT NULL,
    `photo3` text NOT NULL,
    `photo4` text NOT NULL,
    `stock` int(11) NOT NULL DEFAULT '1',
    `color` varchar(191) NOT NULL,
    `condition` enum('default','new','hot') NOT NULL DEFAULT '''default''',
    `status` enum('active','inactive') NOT NULL DEFAULT '''inactive''',
    `price` decimal(10,0) NOT NULL,
    `coupon_id` bigint(20) unsigned NULL DEFAULT 'NULL',
    `cat_id` bigint(20) unsigned NULL DEFAULT 'NULL',
    `child_cat_id` bigint(20) unsigned NULL DEFAULT 'NULL',
    `brand_id` bigint(20) unsigned NULL DEFAULT 'NULL',
    PRIMARY KEY (`id`),
    CONSTRAINT `products_brand_id_foreign` FOREIGN KEY (`brand_id`) REFERENCES `brands` (`id`) ON DELETE SET NULL,
    CONSTRAINT `products_cat_id_foreign` FOREIGN KEY (`cat_id`) REFERENCES `categories` (`id`) ON DELETE SET NULL,
    CONSTRAINT `products_child_cat_id_foreign` FOREIGN KEY (`child_cat_id`) REFERENCES `categories` (`id`) ON DELETE SET NULL,
    CONSTRAINT `products_coupon_id_foreign` FOREIGN KEY (`coupon_id`) REFERENCES `coupons` (`id`) ON DELETE SET NULL
);

CREATE TABLE `post_comments` (
    `id` bigint(20) unsigned NOT NULL AUTO_INCREMENT,
    `user_id` bigint(20) unsigned NULL DEFAULT 'NULL',
    `post_id` bigint(20) unsigned NULL DEFAULT 'NULL',
    `comment` text NOT NULL,
    `status` enum('active','inactive') NOT NULL DEFAULT '''active''',
    `parent_id` bigint(20) unsigned NULL DEFAULT 'NULL',
    PRIMARY KEY (`id`),
    CONSTRAINT `post_comments_post_id_foreign` FOREIGN KEY (`post_id`) REFERENCES `posts` (`id`) ON DELETE SET NULL,
    CONSTRAINT `post_comments_user_id_foreign` FOREIGN KEY (`user_id`) REFERENCES `users` (`id`) ON DELETE SET NULL
);

CREATE TABLE `carts` (
    `id` bigint(20) unsigned NOT NULL AUTO_INCREMENT,
    `product_id` bigint(20) unsigned NOT NULL,
    `order_id` bigint(20) unsigned NULL DEFAULT 'NULL',
    `user_id` bigint(20) unsigned NULL DEFAULT 'NULL',
    `price` decimal(10,0) NOT NULL,
    `status` enum('new','progress','delivered','cancel') NOT NULL DEFAULT '''new''',
    `quantity` int(11) NOT NULL,
    `amount` decimal(10,0) NOT NULL,
    PRIMARY KEY (`id`),
    CONSTRAINT `carts_order_id_foreign` FOREIGN KEY (`order_id`) REFERENCES `orders` (`id`) ON DELETE SET NULL,
    CONSTRAINT `carts_product_id_foreign` FOREIGN KEY (`product_id`) REFERENCES `products` (`id`) ON DELETE CASCADE,
    CONSTRAINT `carts_user_id_foreign` FOREIGN KEY (`user_id`) REFERENCES `users` (`id`) ON DELETE CASCADE
);

CREATE TABLE `product_reviews` (
    `id` bigint(20) unsigned NOT NULL AUTO_INCREMENT,
    `user_id` bigint(20) unsigned NULL DEFAULT 'NULL',
    `product_id` bigint(20) unsigned NULL DEFAULT 'NULL',
    `rate` tinyint(4) NOT NULL,
    `review` text NULL DEFAULT 'NULL',
    `status` enum('active','inactive') NOT NULL DEFAULT '''active''',
    PRIMARY KEY (`id`),
    CONSTRAINT `product_reviews_product_id_foreign` FOREIGN KEY (`product_id`) REFERENCES `products` (`id`) ON DELETE SET NULL,
    CONSTRAINT `product_reviews_user_id_foreign` FOREIGN KEY (`user_id`) REFERENCES `users` (`id`) ON DELETE SET NULL
);

CREATE TABLE `wishlists` (
    `id` bigint(20) unsigned NOT NULL AUTO_INCREMENT,
    `product_id` bigint(20) unsigned NOT NULL,
    `cart_id` bigint(20) unsigned NULL DEFAULT 'NULL',
    `user_id` bigint(20) unsigned NULL DEFAULT 'NULL',
    `price` decimal(10,0) NOT NULL,
    `quantity` int(11) NOT NULL,
    `amount` decimal(10,0) NOT NULL,
    PRIMARY KEY (`id`),
    CONSTRAINT `wishlists_cart_id_foreign` FOREIGN KEY (`cart_id`) REFERENCES `carts` (`id`) ON DELETE SET NULL,
    CONSTRAINT `wishlists_product_id_foreign` FOREIGN KEY (`product_id`) REFERENCES `products` (`id`) ON DELETE CASCADE,
    CONSTRAINT `wishlists_user_id_foreign` FOREIGN KEY (`user_id`) REFERENCES `users` (`id`) ON DELETE SET NULL
);

CREATE UNIQUE INDEX `banners_slug_unique` ON `banners` (`slug`);

CREATE UNIQUE INDEX `brands_slug_unique` ON `brands` (`slug`);

CREATE INDEX `carts_order_id_foreign` ON `carts` (`order_id`);

CREATE INDEX `carts_product_id_foreign` ON `carts` (`product_id`);

CREATE INDEX `carts_user_id_foreign` ON `carts` (`user_id`);

CREATE INDEX `categories_added_by_foreign` ON `categories` (`added_by`);

CREATE INDEX `categories_parent_id_foreign` ON `categories` (`parent_id`);

CREATE UNIQUE INDEX `categories_slug_unique` ON `categories` (`slug`);

CREATE UNIQUE INDEX `coupons_code_unique` ON `coupons` (`code`);

CREATE INDEX `notifications_notifiable_type_notifiable_id_index` ON `notifications` (`notifiable_type`, `notifiable_id`);

CREATE INDEX `orders_coupon_id_foreign` ON `orders` (`coupon_id`);

CREATE UNIQUE INDEX `orders_order_number_unique` ON `orders` (`order_number`);

CREATE INDEX `orders_shipping_id_foreign` ON `orders` (`shipping_id`);

CREATE INDEX `orders_user_id_foreign` ON `orders` (`user_id`);

CREATE INDEX `password_resets_email_index` ON `password_resets` (`email`);

CREATE UNIQUE INDEX `post_categories_slug_unique` ON `post_categories` (`slug`);

CREATE INDEX `post_comments_post_id_foreign` ON `post_comments` (`post_id`);

CREATE INDEX `post_comments_user_id_foreign` ON `post_comments` (`user_id`);

CREATE UNIQUE INDEX `post_tags_slug_unique` ON `post_tags` (`slug`);

CREATE INDEX `posts_added_by_foreign` ON `posts` (`added_by`);

CREATE INDEX `posts_post_cat_id_foreign` ON `posts` (`post_cat_id`);

CREATE INDEX `posts_post_tag_id_foreign` ON `posts` (`post_tag_id`);

CREATE UNIQUE INDEX `posts_slug_unique` ON `posts` (`slug`);

CREATE INDEX `product_reviews_product_id_foreign` ON `product_reviews` (`product_id`);

CREATE INDEX `product_reviews_user_id_foreign` ON `product_reviews` (`user_id`);

CREATE INDEX `products_brand_id_foreign` ON `products` (`brand_id`);

CREATE INDEX `products_cat_id_foreign` ON `products` (`cat_id`);

CREATE INDEX `products_child_cat_id_foreign` ON `products` (`child_cat_id`);

CREATE INDEX `products_coupon_id_foreign` ON `products` (`coupon_id`);

CREATE UNIQUE INDEX `products_slug_unique` ON `products` (`slug`);

CREATE UNIQUE INDEX `users_email_unique` ON `users` (`email`);

CREATE INDEX `wishlists_cart_id_foreign` ON `wishlists` (`cart_id`);

CREATE INDEX `wishlists_product_id_foreign` ON `wishlists` (`product_id`);

CREATE INDEX `wishlists_user_id_foreign` ON `wishlists` (`user_id`);

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20211106163513_Init', '3.1.9');

