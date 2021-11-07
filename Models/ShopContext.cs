using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace comestic.Models
{
    public partial class ShopContext : DbContext
    {
        public ShopContext()
        {
        }

        public ShopContext(DbContextOptions<ShopContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Banners> Banners { get; set; }
        public virtual DbSet<Brands> Brands { get; set; }
        public virtual DbSet<Carts> Carts { get; set; }
        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<Coupons> Coupons { get; set; }
        public virtual DbSet<Efmigrationshistory> Efmigrationshistory { get; set; }
        public virtual DbSet<Messages> Messages { get; set; }
        public virtual DbSet<Notifications> Notifications { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<PasswordResets> PasswordResets { get; set; }
        public virtual DbSet<PostCategories> PostCategories { get; set; }
        public virtual DbSet<PostComments> PostComments { get; set; }
        public virtual DbSet<PostTags> PostTags { get; set; }
        public virtual DbSet<Posts> Posts { get; set; }
        public virtual DbSet<ProductReviews> ProductReviews { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<Settings> Settings { get; set; }
        public virtual DbSet<Shippings> Shippings { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Wishlists> Wishlists { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
// #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySQL("server=localhost; username=root;password=01672362745Ngan;database=comestic_csharp;SslMode = none");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Banners>(entity =>
            {
                entity.ToTable("banners");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20) unsigned");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Photo)
                    .HasColumnName("photo")
                    .HasMaxLength(191)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Slug)
                    .IsRequired()
                    .HasColumnName("slug")
                    .HasMaxLength(191);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnName("status")
                    .HasColumnType("enum('active','inactive')")
                    .HasDefaultValueSql("'''inactive'''");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasMaxLength(191);

                entity.Property(e => e.Created_at)
                    .HasColumnName("created_at");

                entity.Property(e => e.Updated_at)
                    .HasColumnName("updated_at");
            });

            modelBuilder.Entity<Brands>(entity =>
            {
                entity.ToTable("brands");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20) unsigned");

                entity.Property(e => e.Slug)
                    .IsRequired()
                    .HasColumnName("slug")
                    .HasMaxLength(191);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnName("status")
                    .HasColumnType("enum('active','inactive')")
                    .HasDefaultValueSql("'''active'''");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasMaxLength(191);
                
                entity.Property(e => e.Created_at)
                    .HasColumnName("created_at");

                entity.Property(e => e.Updated_at)
                    .HasColumnName("updated_at");
            });

            modelBuilder.Entity<Carts>(entity =>
            {
                entity.ToTable("carts");

                entity.Property(e => e.OrderId)
                    .HasColumnName("order_id")
                    .HasColumnType("bigint(20) unsigned")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasColumnType("decimal(10,0)");

                entity.Property(e => e.ProductId)
                    .HasColumnName("product_id")
                    .HasColumnType("bigint(20) unsigned");

                entity.Property(e => e.Quantity)
                    .HasColumnName("quantity")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnName("status")
                    .HasColumnType("enum('new','progress','delivered','cancel')")
                    .HasDefaultValueSql("'''new'''");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("bigint(20) unsigned")
                    .HasDefaultValueSql("'NULL'");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Carts)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("carts_order_id_foreign");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Carts)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("carts_product_id_foreign");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Carts)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("carts_user_id_foreign");

                entity.Property(e => e.Created_at)
                    .HasColumnName("created_at");

                entity.Property(e => e.Updated_at)
                    .HasColumnName("updated_at");
            });

            modelBuilder.Entity<Categories>(entity =>
            {
                entity.ToTable("categories");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20) unsigned");

                entity.Property(e => e.AddedBy)
                    .HasColumnName("added_by")
                    .HasColumnType("bigint(20) unsigned")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.IsParent)
                    .IsRequired()
                    .HasColumnName("is_parent")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.ParentId)
                    .HasColumnName("parent_id")
                    .HasColumnType("bigint(20) unsigned")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Photo)
                    .HasColumnName("photo")
                    .HasMaxLength(191)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Slug)
                    .IsRequired()
                    .HasColumnName("slug")
                    .HasMaxLength(191);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnName("status")
                    .HasColumnType("enum('active','inactive')")
                    .HasDefaultValueSql("'''inactive'''");

                entity.Property(e => e.Summary)
                    .HasColumnName("summary")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasMaxLength(191);

                entity.HasOne(d => d.AddedByNavigation)
                    .WithMany(p => p.Categories)
                    .HasForeignKey(d => d.AddedBy)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("categories_added_by_foreign");

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.InverseParent)
                    .HasForeignKey(d => d.ParentId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("categories_parent_id_foreign");

                entity.Property(e => e.Created_at)
                    .HasColumnName("created_at");

                entity.Property(e => e.Updated_at)
                    .HasColumnName("updated_at");
            });

            modelBuilder.Entity<Coupons>(entity =>
            {
                entity.ToTable("coupons");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20) unsigned");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasColumnName("code")
                    .HasMaxLength(191);

                entity.Property(e => e.IsVoucher).HasColumnName("is_voucher");

                entity.Property(e => e.Quantity)
                    .HasColumnName("quantity")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnName("status")
                    .HasColumnType("enum('active','inactive')")
                    .HasDefaultValueSql("'''active'''");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnName("type")
                    .HasColumnType("enum('fixed','percent')")
                    .HasDefaultValueSql("'''fixed'''");

                entity.Property(e => e.Value)
                    .HasColumnName("value")
                    .HasColumnType("decimal(20,2)");
                
                entity.Property(e => e.Created_at)
                    .HasColumnName("created_at");

                entity.Property(e => e.Ended_at)
                    .HasColumnName("ended_at");

                entity.Property(e => e.Updated_at)
                    .HasColumnName("updated_at");
            });

            modelBuilder.Entity<Efmigrationshistory>(entity =>
            {
                entity.HasKey(e => e.MigrationId)
                    .HasName("PRIMARY");

                entity.ToTable("__efmigrationshistory");

                entity.Property(e => e.MigrationId).HasMaxLength(150);

                entity.Property(e => e.ProductVersion)
                    .IsRequired()
                    .HasMaxLength(32);
            });

            modelBuilder.Entity<Messages>(entity =>
            {
                entity.ToTable("messages");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20) unsigned");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(191);

                entity.Property(e => e.Message)
                    .IsRequired()
                    .HasColumnName("message")
                    .HasColumnType("longtext");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(191);

                entity.Property(e => e.Phone)
                    .HasColumnName("phone")
                    .HasMaxLength(191)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Photo)
                    .HasColumnName("photo")
                    .HasMaxLength(191)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Subject)
                    .IsRequired()
                    .HasColumnName("subject");

                entity.Property(e => e.Created_at)
                    .HasColumnName("created_at");
                
                entity.Property(e => e.Read_at)
                    .HasColumnName("read_at");

                entity.Property(e => e.Updated_at)
                    .HasColumnName("updated_at");
            });

            modelBuilder.Entity<Notifications>(entity =>
            {
                entity.ToTable("notifications");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasMaxLength(36)
                    .IsFixedLength();

                entity.Property(e => e.Data)
                    .IsRequired()
                    .HasColumnName("data");

                entity.Property(e => e.NotifiableId)
                    .HasColumnName("notifiable_id")
                    .HasColumnType("bigint(20) unsigned");

                entity.Property(e => e.NotifiableType)
                    .IsRequired()
                    .HasColumnName("notifiable_type")
                    .HasMaxLength(191);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnName("type")
                    .HasMaxLength(191);
                
                entity.Property(e => e.Created_at)
                    .HasColumnName("created_at");

                entity.Property(e => e.Read_at)
                    .HasColumnName("read_at");
            
                entity.Property(e => e.Updated_at)
                    .HasColumnName("updated_at");
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.ToTable("orders");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20) unsigned");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasColumnName("address");

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasColumnName("country")
                    .HasMaxLength(191);

                entity.Property(e => e.CouponId)
                    .HasColumnName("coupon_id")
                    .HasColumnType("bigint(20) unsigned")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(191);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("first_name")
                    .HasMaxLength(191);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("last_name")
                    .HasMaxLength(191);

                entity.Property(e => e.OrderNumber)
                    .IsRequired()
                    .HasColumnName("order_number")
                    .HasMaxLength(191);

                entity.Property(e => e.PaymentMethod)
                    .IsRequired()
                    .HasColumnName("payment_method")
                    .HasColumnType("enum('cod','paypal')")
                    .HasDefaultValueSql("'''cod'''");

                entity.Property(e => e.PaymentStatus)
                    .IsRequired()
                    .HasColumnName("payment_status")
                    .HasColumnType("enum('paid','unpaid')")
                    .HasDefaultValueSql("'''unpaid'''");

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasColumnName("phone")
                    .HasMaxLength(191);

                entity.Property(e => e.Quantity)
                    .HasColumnName("quantity")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ShippingId)
                    .HasColumnName("shipping_id")
                    .HasColumnType("bigint(20) unsigned")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnName("status")
                    .HasColumnType("enum('new','process','delivered','cancel')")
                    .HasDefaultValueSql("'''new'''");

                entity.Property(e => e.SubTotal)
                    .HasColumnName("sub_total")
                    .HasColumnType("decimal(10,0)");

                entity.Property(e => e.TotalAmount)
                    .HasColumnName("total_amount")
                    .HasColumnType("decimal(10,0)");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("bigint(20) unsigned")
                    .HasDefaultValueSql("'NULL'");

                entity.HasOne(d => d.Coupon)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CouponId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("orders_coupon_id_foreign");

                entity.HasOne(d => d.Shipping)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.ShippingId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("orders_shipping_id_foreign");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("orders_user_id_foreign");
                
                entity.Property(e => e.Created_at)
                    .HasColumnName("created_at");

                entity.Property(e => e.Updated_at)
                    .HasColumnName("updated_at");
            });

            modelBuilder.Entity<PasswordResets>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("password_resets");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(191);

                entity.Property(e => e.Token)
                    .IsRequired()
                    .HasColumnName("token")
                    .HasMaxLength(191);

                entity.Property(e => e.Created_at)
                    .HasColumnName("created_at");
            });

            modelBuilder.Entity<PostCategories>(entity =>
            {
                entity.ToTable("post_categories");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20) unsigned");

                entity.Property(e => e.Slug)
                    .IsRequired()
                    .HasColumnName("slug")
                    .HasMaxLength(191);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnName("status")
                    .HasColumnType("enum('active','inactive')")
                    .HasDefaultValueSql("'''active'''");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasMaxLength(191);

                entity.Property(e => e.Created_at)
                    .HasColumnName("created_at");

                entity.Property(e => e.Updated_at)
                    .HasColumnName("updated_at");
            });

            modelBuilder.Entity<PostComments>(entity =>
            {
                entity.ToTable("post_comments");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20) unsigned");

                entity.Property(e => e.Comment)
                    .IsRequired()
                    .HasColumnName("comment");

                entity.Property(e => e.ParentId)
                    .HasColumnName("parent_id")
                    .HasColumnType("bigint(20) unsigned")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.PostId)
                    .HasColumnName("post_id")
                    .HasColumnType("bigint(20) unsigned")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnName("status")
                    .HasColumnType("enum('active','inactive')")
                    .HasDefaultValueSql("'''active'''");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("bigint(20) unsigned")
                    .HasDefaultValueSql("'NULL'");

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.PostComments)
                    .HasForeignKey(d => d.PostId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("post_comments_post_id_foreign");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.PostComments)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("post_comments_user_id_foreign");

                entity.Property(e => e.Created_at)
                    .HasColumnName("created_at");

                entity.Property(e => e.Updated_at)
                    .HasColumnName("updated_at");
            });

            modelBuilder.Entity<PostTags>(entity =>
            {
                entity.ToTable("post_tags");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20) unsigned");

                entity.Property(e => e.Slug)
                    .IsRequired()
                    .HasColumnName("slug")
                    .HasMaxLength(191);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnName("status")
                    .HasColumnType("enum('active','inactive')")
                    .HasDefaultValueSql("'''active'''");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasMaxLength(191);

                entity.Property(e => e.Created_at)
                    .HasColumnName("created_at");

                entity.Property(e => e.Updated_at)
                    .HasColumnName("updated_at");
            });

            modelBuilder.Entity<Posts>(entity =>
            {
                entity.ToTable("posts");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20) unsigned");

                entity.Property(e => e.AddedBy)
                    .HasColumnName("added_by")
                    .HasColumnType("bigint(20) unsigned")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("longtext")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Photo)
                    .HasColumnName("photo")
                    .HasMaxLength(191)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.PostCatId)
                    .HasColumnName("post_cat_id")
                    .HasColumnType("bigint(20) unsigned")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.PostTagId)
                    .HasColumnName("post_tag_id")
                    .HasColumnType("bigint(20) unsigned")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Quote)
                    .HasColumnName("quote")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Slug)
                    .IsRequired()
                    .HasColumnName("slug")
                    .HasMaxLength(191);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnName("status")
                    .HasColumnType("enum('active','inactive')")
                    .HasDefaultValueSql("'''active'''");

                entity.Property(e => e.Summary)
                    .IsRequired()
                    .HasColumnName("summary");

                entity.Property(e => e.Tags)
                    .HasColumnName("tags")
                    .HasMaxLength(191)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasMaxLength(191);

                entity.HasOne(d => d.AddedByNavigation)
                    .WithMany(p => p.Posts)
                    .HasForeignKey(d => d.AddedBy)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("posts_added_by_foreign");

                entity.HasOne(d => d.PostCat)
                    .WithMany(p => p.Posts)
                    .HasForeignKey(d => d.PostCatId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("posts_post_cat_id_foreign");

                entity.HasOne(d => d.PostTag)
                    .WithMany(p => p.Posts)
                    .HasForeignKey(d => d.PostTagId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("posts_post_tag_id_foreign");

                entity.Property(e => e.Created_at)
                    .HasColumnName("created_at");

                entity.Property(e => e.Updated_at)
                    .HasColumnName("updated_at");
            });

            modelBuilder.Entity<ProductReviews>(entity =>
            {
                entity.ToTable("product_reviews");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20) unsigned");

                entity.Property(e => e.ProductId)
                    .HasColumnName("product_id")
                    .HasColumnType("bigint(20) unsigned")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Rate)
                    .HasColumnName("rate")
                    .HasColumnType("tinyint(4)");

                entity.Property(e => e.Review)
                    .HasColumnName("review")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnName("status")
                    .HasColumnType("enum('active','inactive')")
                    .HasDefaultValueSql("'''active'''");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("bigint(20) unsigned")
                    .HasDefaultValueSql("'NULL'");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductReviews)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("product_reviews_product_id_foreign");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ProductReviews)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("product_reviews_user_id_foreign");

                entity.Property(e => e.Created_at)
                    .HasColumnName("created_at");

                entity.Property(e => e.Updated_at)
                    .HasColumnName("updated_at");
            });

            modelBuilder.Entity<Products>(entity =>
            {
                entity.ToTable("products");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20) unsigned");

                entity.Property(e => e.BrandId)
                    .HasColumnName("brand_id")
                    .HasColumnType("bigint(20) unsigned")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.CatId)
                    .HasColumnName("cat_id")
                    .HasColumnType("bigint(20) unsigned")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.ChildCatId)
                    .HasColumnName("child_cat_id")
                    .HasColumnType("bigint(20) unsigned")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Color)
                    .IsRequired()
                    .HasColumnName("color")
                    .HasMaxLength(191);

                entity.Property(e => e.Condition)
                    .IsRequired()
                    .HasColumnName("condition")
                    .HasColumnType("enum('default','new','hot')")
                    .HasDefaultValueSql("'''default'''");

                entity.Property(e => e.CouponId)
                    .HasColumnName("coupon_id")
                    .HasColumnType("bigint(20) unsigned")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("longtext")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Photo1)
                    .IsRequired()
                    .HasColumnName("photo1");

                entity.Property(e => e.Photo2)
                    .IsRequired()
                    .HasColumnName("photo2");

                entity.Property(e => e.Photo3)
                    .IsRequired()
                    .HasColumnName("photo3");

                entity.Property(e => e.Photo4)
                    .IsRequired()
                    .HasColumnName("photo4");

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasColumnType("decimal(10,0)");

                entity.Property(e => e.Slug)
                    .IsRequired()
                    .HasColumnName("slug")
                    .HasMaxLength(191);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnName("status")
                    .HasColumnType("enum('active','inactive')")
                    .HasDefaultValueSql("'''inactive'''");

                entity.Property(e => e.Stock)
                    .HasColumnName("stock")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Summary)
                    .IsRequired()
                    .HasColumnName("summary");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasMaxLength(191);

                entity.HasOne(d => d.Brand)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.BrandId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("products_brand_id_foreign");

                entity.HasOne(d => d.Cat)
                    .WithMany(p => p.ProductsCat)
                    .HasForeignKey(d => d.CatId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("products_cat_id_foreign");

                entity.HasOne(d => d.ChildCat)
                    .WithMany(p => p.ProductsChildCat)
                    .HasForeignKey(d => d.ChildCatId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("products_child_cat_id_foreign");

                entity.HasOne(d => d.Coupon)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CouponId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("products_coupon_id_foreign");

                entity.Property(e => e.Created_at)
                    .HasColumnName("created_at");

                entity.Property(e => e.Updated_at)
                    .HasColumnName("updated_at");
            });

            modelBuilder.Entity<Settings>(entity =>
            {
                entity.ToTable("settings");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20) unsigned");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasColumnName("address")
                    .HasMaxLength(191);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasColumnType("longtext");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(191);

                entity.Property(e => e.Logo)
                    .IsRequired()
                    .HasColumnName("logo")
                    .HasMaxLength(191);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasColumnName("phone")
                    .HasMaxLength(191);

                entity.Property(e => e.Photo)
                    .IsRequired()
                    .HasColumnName("photo")
                    .HasMaxLength(191);

                entity.Property(e => e.ShortDes)
                    .IsRequired()
                    .HasColumnName("short_des");

                entity.Property(e => e.Created_at)
                    .HasColumnName("created_at");

                entity.Property(e => e.Updated_at)
                    .HasColumnName("updated_at");
            });

            modelBuilder.Entity<Shippings>(entity =>
            {
                entity.ToTable("shippings");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20) unsigned");

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasColumnType("decimal(8,2)");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnName("status")
                    .HasColumnType("enum('active','inactive')")
                    .HasDefaultValueSql("'''active'''");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnName("type")
                    .HasMaxLength(191);

                entity.Property(e => e.Created_at)
                    .HasColumnName("created_at");

                entity.Property(e => e.Updated_at)
                    .HasColumnName("updated_at");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.ToTable("users");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20) unsigned");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(191)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(191);

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasMaxLength(191)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Photo)
                    .HasColumnName("photo")
                    .HasMaxLength(191)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.RememberToken)
                    .HasColumnName("remember_token")
                    .HasMaxLength(100)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Role)
                    .IsRequired()
                    .HasColumnName("role")
                    .HasColumnType("enum('admin','user')")
                    .HasDefaultValueSql("'''user'''");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnName("status")
                    .HasColumnType("enum('active','inactive')")
                    .HasDefaultValueSql("'''active'''");

                entity.Property(e => e.Created_at)
                    .HasColumnName("created_at");

                entity.Property(e => e.Updated_at)
                    .HasColumnName("updated_at");
            });

            modelBuilder.Entity<Wishlists>(entity =>
            {
                entity.ToTable("wishlists");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20) unsigned");

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasColumnType("decimal(10,0)");

                entity.Property(e => e.CartId)
                    .HasColumnName("cart_id")
                    .HasColumnType("bigint(20) unsigned")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasColumnType("decimal(10,0)");

                entity.Property(e => e.ProductId)
                    .HasColumnName("product_id")
                    .HasColumnType("bigint(20) unsigned");

                entity.Property(e => e.Quantity)
                    .HasColumnName("quantity")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("bigint(20) unsigned")
                    .HasDefaultValueSql("'NULL'");

                entity.HasOne(d => d.Cart)
                    .WithMany(p => p.Wishlists)
                    .HasForeignKey(d => d.CartId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("wishlists_cart_id_foreign");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Wishlists)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("wishlists_product_id_foreign");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Wishlists)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("wishlists_user_id_foreign");

                entity.Property(e => e.Created_at)
                    .HasColumnName("created_at");

                entity.Property(e => e.Updated_at)
                    .HasColumnName("updated_at");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
