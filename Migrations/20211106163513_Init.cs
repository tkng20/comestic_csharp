using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Metadata;

namespace comestic.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "__efmigrationshistory",
                columns: table => new
                {
                    MigrationId = table.Column<string>(maxLength: 150, nullable: false),
                    ProductVersion = table.Column<string>(maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.MigrationId);
                });

            migrationBuilder.CreateTable(
                name: "banners",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint(20) unsigned", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    title = table.Column<string>(maxLength: 191, nullable: false),
                    slug = table.Column<string>(maxLength: 191, nullable: false),
                    photo = table.Column<string>(maxLength: 191, nullable: true, defaultValueSql: "'NULL'"),
                    description = table.Column<string>(nullable: true, defaultValueSql: "'NULL'"),
                    status = table.Column<string>(type: "enum('active','inactive')", nullable: false, defaultValueSql: "'''inactive'''")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_banners", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "brands",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint(20) unsigned", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    title = table.Column<string>(maxLength: 191, nullable: false),
                    slug = table.Column<string>(maxLength: 191, nullable: false),
                    status = table.Column<string>(type: "enum('active','inactive')", nullable: false, defaultValueSql: "'''active'''")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_brands", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "coupons",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint(20) unsigned", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    code = table.Column<string>(maxLength: 191, nullable: false),
                    type = table.Column<string>(type: "enum('fixed','percent')", nullable: false, defaultValueSql: "'''fixed'''"),
                    value = table.Column<decimal>(type: "decimal(20,2)", nullable: false),
                    status = table.Column<string>(type: "enum('active','inactive')", nullable: false, defaultValueSql: "'''active'''"),
                    is_voucher = table.Column<bool>(nullable: false),
                    quantity = table.Column<int>(type: "int(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_coupons", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "messages",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint(20) unsigned", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(maxLength: 191, nullable: false),
                    subject = table.Column<string>(nullable: false),
                    email = table.Column<string>(maxLength: 191, nullable: false),
                    photo = table.Column<string>(maxLength: 191, nullable: true, defaultValueSql: "'NULL'"),
                    phone = table.Column<string>(maxLength: 191, nullable: true, defaultValueSql: "'NULL'"),
                    message = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_messages", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "notifications",
                columns: table => new
                {
                    id = table.Column<string>(fixedLength: true, maxLength: 36, nullable: false),
                    type = table.Column<string>(maxLength: 191, nullable: false),
                    notifiable_type = table.Column<string>(maxLength: 191, nullable: false),
                    notifiable_id = table.Column<long>(type: "bigint(20) unsigned", nullable: false),
                    data = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_notifications", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "password_resets",
                columns: table => new
                {
                    email = table.Column<string>(maxLength: 191, nullable: false),
                    token = table.Column<string>(maxLength: 191, nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "post_categories",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint(20) unsigned", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    title = table.Column<string>(maxLength: 191, nullable: false),
                    slug = table.Column<string>(maxLength: 191, nullable: false),
                    status = table.Column<string>(type: "enum('active','inactive')", nullable: false, defaultValueSql: "'''active'''")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_post_categories", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "post_tags",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint(20) unsigned", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    title = table.Column<string>(maxLength: 191, nullable: false),
                    slug = table.Column<string>(maxLength: 191, nullable: false),
                    status = table.Column<string>(type: "enum('active','inactive')", nullable: false, defaultValueSql: "'''active'''")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_post_tags", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "settings",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint(20) unsigned", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    description = table.Column<string>(type: "longtext", nullable: false),
                    short_des = table.Column<string>(nullable: false),
                    logo = table.Column<string>(maxLength: 191, nullable: false),
                    photo = table.Column<string>(maxLength: 191, nullable: false),
                    address = table.Column<string>(maxLength: 191, nullable: false),
                    phone = table.Column<string>(maxLength: 191, nullable: false),
                    email = table.Column<string>(maxLength: 191, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_settings", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "shippings",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint(20) unsigned", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    type = table.Column<string>(maxLength: 191, nullable: false),
                    price = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    status = table.Column<string>(type: "enum('active','inactive')", nullable: false, defaultValueSql: "'''active'''")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_shippings", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint(20) unsigned", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(maxLength: 191, nullable: false),
                    email = table.Column<string>(maxLength: 191, nullable: true, defaultValueSql: "'NULL'"),
                    password = table.Column<string>(maxLength: 191, nullable: true, defaultValueSql: "'NULL'"),
                    photo = table.Column<string>(maxLength: 191, nullable: true, defaultValueSql: "'NULL'"),
                    role = table.Column<string>(type: "enum('admin','user')", nullable: false, defaultValueSql: "'''user'''"),
                    provider = table.Column<string>(maxLength: 191, nullable: true, defaultValueSql: "'NULL'"),
                    provider_id = table.Column<string>(maxLength: 191, nullable: true, defaultValueSql: "'NULL'"),
                    status = table.Column<string>(type: "enum('active','inactive')", nullable: false, defaultValueSql: "'''active'''"),
                    remember_token = table.Column<string>(maxLength: 100, nullable: true, defaultValueSql: "'NULL'")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint(20) unsigned", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    title = table.Column<string>(maxLength: 191, nullable: false),
                    slug = table.Column<string>(maxLength: 191, nullable: false),
                    summary = table.Column<string>(nullable: true, defaultValueSql: "'NULL'"),
                    photo = table.Column<string>(maxLength: 191, nullable: true, defaultValueSql: "'NULL'"),
                    is_parent = table.Column<bool>(nullable: false, defaultValueSql: "'1'"),
                    parent_id = table.Column<long>(type: "bigint(20) unsigned", nullable: true, defaultValueSql: "'NULL'"),
                    added_by = table.Column<long>(type: "bigint(20) unsigned", nullable: true, defaultValueSql: "'NULL'"),
                    status = table.Column<string>(type: "enum('active','inactive')", nullable: false, defaultValueSql: "'''inactive'''")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.id);
                    table.ForeignKey(
                        name: "categories_added_by_foreign",
                        column: x => x.added_by,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "categories_parent_id_foreign",
                        column: x => x.parent_id,
                        principalTable: "categories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "orders",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint(20) unsigned", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    order_number = table.Column<string>(maxLength: 191, nullable: false),
                    user_id = table.Column<long>(type: "bigint(20) unsigned", nullable: true, defaultValueSql: "'NULL'"),
                    sub_total = table.Column<decimal>(type: "decimal(10,0)", nullable: false),
                    shipping_id = table.Column<long>(type: "bigint(20) unsigned", nullable: true, defaultValueSql: "'NULL'"),
                    coupon_id = table.Column<long>(type: "bigint(20) unsigned", nullable: true, defaultValueSql: "'NULL'"),
                    total_amount = table.Column<decimal>(type: "decimal(10,0)", nullable: false),
                    quantity = table.Column<int>(type: "int(11)", nullable: false),
                    payment_method = table.Column<string>(type: "enum('cod','paypal')", nullable: false, defaultValueSql: "'''cod'''"),
                    payment_status = table.Column<string>(type: "enum('paid','unpaid')", nullable: false, defaultValueSql: "'''unpaid'''"),
                    status = table.Column<string>(type: "enum('new','process','delivered','cancel')", nullable: false, defaultValueSql: "'''new'''"),
                    first_name = table.Column<string>(maxLength: 191, nullable: false),
                    last_name = table.Column<string>(maxLength: 191, nullable: false),
                    email = table.Column<string>(maxLength: 191, nullable: false),
                    phone = table.Column<string>(maxLength: 191, nullable: false),
                    country = table.Column<string>(maxLength: 191, nullable: false),
                    address = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orders", x => x.id);
                    table.ForeignKey(
                        name: "orders_coupon_id_foreign",
                        column: x => x.coupon_id,
                        principalTable: "coupons",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "orders_shipping_id_foreign",
                        column: x => x.shipping_id,
                        principalTable: "shippings",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "orders_user_id_foreign",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "posts",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint(20) unsigned", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    title = table.Column<string>(maxLength: 191, nullable: false),
                    slug = table.Column<string>(maxLength: 191, nullable: false),
                    summary = table.Column<string>(nullable: false),
                    description = table.Column<string>(type: "longtext", nullable: true, defaultValueSql: "'NULL'"),
                    quote = table.Column<string>(nullable: true, defaultValueSql: "'NULL'"),
                    photo = table.Column<string>(maxLength: 191, nullable: true, defaultValueSql: "'NULL'"),
                    tags = table.Column<string>(maxLength: 191, nullable: true, defaultValueSql: "'NULL'"),
                    post_cat_id = table.Column<long>(type: "bigint(20) unsigned", nullable: true, defaultValueSql: "'NULL'"),
                    post_tag_id = table.Column<long>(type: "bigint(20) unsigned", nullable: true, defaultValueSql: "'NULL'"),
                    added_by = table.Column<long>(type: "bigint(20) unsigned", nullable: true, defaultValueSql: "'NULL'"),
                    status = table.Column<string>(type: "enum('active','inactive')", nullable: false, defaultValueSql: "'''active'''")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_posts", x => x.id);
                    table.ForeignKey(
                        name: "posts_added_by_foreign",
                        column: x => x.added_by,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "posts_post_cat_id_foreign",
                        column: x => x.post_cat_id,
                        principalTable: "post_categories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "posts_post_tag_id_foreign",
                        column: x => x.post_tag_id,
                        principalTable: "post_tags",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint(20) unsigned", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    title = table.Column<string>(maxLength: 191, nullable: false),
                    slug = table.Column<string>(maxLength: 191, nullable: false),
                    summary = table.Column<string>(nullable: false),
                    description = table.Column<string>(type: "longtext", nullable: true, defaultValueSql: "'NULL'"),
                    photo1 = table.Column<string>(nullable: false),
                    photo2 = table.Column<string>(nullable: false),
                    photo3 = table.Column<string>(nullable: false),
                    photo4 = table.Column<string>(nullable: false),
                    stock = table.Column<int>(type: "int(11)", nullable: false, defaultValueSql: "'1'"),
                    color = table.Column<string>(maxLength: 191, nullable: false),
                    condition = table.Column<string>(type: "enum('default','new','hot')", nullable: false, defaultValueSql: "'''default'''"),
                    status = table.Column<string>(type: "enum('active','inactive')", nullable: false, defaultValueSql: "'''inactive'''"),
                    price = table.Column<decimal>(type: "decimal(10,0)", nullable: false),
                    coupon_id = table.Column<long>(type: "bigint(20) unsigned", nullable: true, defaultValueSql: "'NULL'"),
                    cat_id = table.Column<long>(type: "bigint(20) unsigned", nullable: true, defaultValueSql: "'NULL'"),
                    child_cat_id = table.Column<long>(type: "bigint(20) unsigned", nullable: true, defaultValueSql: "'NULL'"),
                    brand_id = table.Column<long>(type: "bigint(20) unsigned", nullable: true, defaultValueSql: "'NULL'")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.id);
                    table.ForeignKey(
                        name: "products_brand_id_foreign",
                        column: x => x.brand_id,
                        principalTable: "brands",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "products_cat_id_foreign",
                        column: x => x.cat_id,
                        principalTable: "categories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "products_child_cat_id_foreign",
                        column: x => x.child_cat_id,
                        principalTable: "categories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "products_coupon_id_foreign",
                        column: x => x.coupon_id,
                        principalTable: "coupons",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "post_comments",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint(20) unsigned", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    user_id = table.Column<long>(type: "bigint(20) unsigned", nullable: true, defaultValueSql: "'NULL'"),
                    post_id = table.Column<long>(type: "bigint(20) unsigned", nullable: true, defaultValueSql: "'NULL'"),
                    comment = table.Column<string>(nullable: false),
                    status = table.Column<string>(type: "enum('active','inactive')", nullable: false, defaultValueSql: "'''active'''"),
                    parent_id = table.Column<long>(type: "bigint(20) unsigned", nullable: true, defaultValueSql: "'NULL'")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_post_comments", x => x.id);
                    table.ForeignKey(
                        name: "post_comments_post_id_foreign",
                        column: x => x.post_id,
                        principalTable: "posts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "post_comments_user_id_foreign",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "carts",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint(20) unsigned", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    product_id = table.Column<long>(type: "bigint(20) unsigned", nullable: false),
                    order_id = table.Column<long>(type: "bigint(20) unsigned", nullable: true, defaultValueSql: "'NULL'"),
                    user_id = table.Column<long>(type: "bigint(20) unsigned", nullable: true, defaultValueSql: "'NULL'"),
                    price = table.Column<decimal>(type: "decimal(10,0)", nullable: false),
                    status = table.Column<string>(type: "enum('new','progress','delivered','cancel')", nullable: false, defaultValueSql: "'''new'''"),
                    quantity = table.Column<int>(type: "int(11)", nullable: false),
                    amount = table.Column<decimal>(type: "decimal(10,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_carts", x => x.id);
                    table.ForeignKey(
                        name: "carts_order_id_foreign",
                        column: x => x.order_id,
                        principalTable: "orders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "carts_product_id_foreign",
                        column: x => x.product_id,
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "carts_user_id_foreign",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "product_reviews",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint(20) unsigned", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    user_id = table.Column<long>(type: "bigint(20) unsigned", nullable: true, defaultValueSql: "'NULL'"),
                    product_id = table.Column<long>(type: "bigint(20) unsigned", nullable: true, defaultValueSql: "'NULL'"),
                    rate = table.Column<byte>(type: "tinyint(4)", nullable: false),
                    review = table.Column<string>(nullable: true, defaultValueSql: "'NULL'"),
                    status = table.Column<string>(type: "enum('active','inactive')", nullable: false, defaultValueSql: "'''active'''")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product_reviews", x => x.id);
                    table.ForeignKey(
                        name: "product_reviews_product_id_foreign",
                        column: x => x.product_id,
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "product_reviews_user_id_foreign",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "wishlists",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint(20) unsigned", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    product_id = table.Column<long>(type: "bigint(20) unsigned", nullable: false),
                    cart_id = table.Column<long>(type: "bigint(20) unsigned", nullable: true, defaultValueSql: "'NULL'"),
                    user_id = table.Column<long>(type: "bigint(20) unsigned", nullable: true, defaultValueSql: "'NULL'"),
                    price = table.Column<decimal>(type: "decimal(10,0)", nullable: false),
                    quantity = table.Column<int>(type: "int(11)", nullable: false),
                    amount = table.Column<decimal>(type: "decimal(10,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_wishlists", x => x.id);
                    table.ForeignKey(
                        name: "wishlists_cart_id_foreign",
                        column: x => x.cart_id,
                        principalTable: "carts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "wishlists_product_id_foreign",
                        column: x => x.product_id,
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "wishlists_user_id_foreign",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "banners_slug_unique",
                table: "banners",
                column: "slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "brands_slug_unique",
                table: "brands",
                column: "slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "carts_order_id_foreign",
                table: "carts",
                column: "order_id");

            migrationBuilder.CreateIndex(
                name: "carts_product_id_foreign",
                table: "carts",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "carts_user_id_foreign",
                table: "carts",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "categories_added_by_foreign",
                table: "categories",
                column: "added_by");

            migrationBuilder.CreateIndex(
                name: "categories_parent_id_foreign",
                table: "categories",
                column: "parent_id");

            migrationBuilder.CreateIndex(
                name: "categories_slug_unique",
                table: "categories",
                column: "slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "coupons_code_unique",
                table: "coupons",
                column: "code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "notifications_notifiable_type_notifiable_id_index",
                table: "notifications",
                columns: new[] { "notifiable_type", "notifiable_id" });

            migrationBuilder.CreateIndex(
                name: "orders_coupon_id_foreign",
                table: "orders",
                column: "coupon_id");

            migrationBuilder.CreateIndex(
                name: "orders_order_number_unique",
                table: "orders",
                column: "order_number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "orders_shipping_id_foreign",
                table: "orders",
                column: "shipping_id");

            migrationBuilder.CreateIndex(
                name: "orders_user_id_foreign",
                table: "orders",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "password_resets_email_index",
                table: "password_resets",
                column: "email");

            migrationBuilder.CreateIndex(
                name: "post_categories_slug_unique",
                table: "post_categories",
                column: "slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "post_comments_post_id_foreign",
                table: "post_comments",
                column: "post_id");

            migrationBuilder.CreateIndex(
                name: "post_comments_user_id_foreign",
                table: "post_comments",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "post_tags_slug_unique",
                table: "post_tags",
                column: "slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "posts_added_by_foreign",
                table: "posts",
                column: "added_by");

            migrationBuilder.CreateIndex(
                name: "posts_post_cat_id_foreign",
                table: "posts",
                column: "post_cat_id");

            migrationBuilder.CreateIndex(
                name: "posts_post_tag_id_foreign",
                table: "posts",
                column: "post_tag_id");

            migrationBuilder.CreateIndex(
                name: "posts_slug_unique",
                table: "posts",
                column: "slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "product_reviews_product_id_foreign",
                table: "product_reviews",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "product_reviews_user_id_foreign",
                table: "product_reviews",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "products_brand_id_foreign",
                table: "products",
                column: "brand_id");

            migrationBuilder.CreateIndex(
                name: "products_cat_id_foreign",
                table: "products",
                column: "cat_id");

            migrationBuilder.CreateIndex(
                name: "products_child_cat_id_foreign",
                table: "products",
                column: "child_cat_id");

            migrationBuilder.CreateIndex(
                name: "products_coupon_id_foreign",
                table: "products",
                column: "coupon_id");

            migrationBuilder.CreateIndex(
                name: "products_slug_unique",
                table: "products",
                column: "slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "users_email_unique",
                table: "users",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "wishlists_cart_id_foreign",
                table: "wishlists",
                column: "cart_id");

            migrationBuilder.CreateIndex(
                name: "wishlists_product_id_foreign",
                table: "wishlists",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "wishlists_user_id_foreign",
                table: "wishlists",
                column: "user_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "__efmigrationshistory");

            migrationBuilder.DropTable(
                name: "banners");

            migrationBuilder.DropTable(
                name: "messages");

            migrationBuilder.DropTable(
                name: "notifications");

            migrationBuilder.DropTable(
                name: "password_resets");

            migrationBuilder.DropTable(
                name: "post_comments");

            migrationBuilder.DropTable(
                name: "product_reviews");

            migrationBuilder.DropTable(
                name: "settings");

            migrationBuilder.DropTable(
                name: "wishlists");

            migrationBuilder.DropTable(
                name: "posts");

            migrationBuilder.DropTable(
                name: "carts");

            migrationBuilder.DropTable(
                name: "post_categories");

            migrationBuilder.DropTable(
                name: "post_tags");

            migrationBuilder.DropTable(
                name: "orders");

            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropTable(
                name: "shippings");

            migrationBuilder.DropTable(
                name: "brands");

            migrationBuilder.DropTable(
                name: "categories");

            migrationBuilder.DropTable(
                name: "coupons");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
