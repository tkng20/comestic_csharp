using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace comestic_csharp.Models
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

        public virtual DbSet<Banner> Banners { get; set; }
        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<Cart> Carts { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Coupon> Coupons { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<Notification> Notifications { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<Postcategory> Postcategories { get; set; }
        public virtual DbSet<Postcomment> Postcomments { get; set; }
        public virtual DbSet<Postsandtag> Postsandtags { get; set; }
        public virtual DbSet<Posttag> Posttags { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Productattribute> Productattributes { get; set; }
        public virtual DbSet<Productreview> Productreviews { get; set; }
        public virtual DbSet<Setting> Settings { get; set; }
        public virtual DbSet<Shipping> Shippings { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Wishlist> Wishlists { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
// #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseLazyLoadingProxies().UseMySql("server=localhost;username=root;password=01672362745Ngan;database=comestic;sslmode=none", Microsoft.EntityFrameworkCore.ServerVersion.FromString("10.4.21-mariadb"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Banner>(entity =>
            {
                entity.ToTable("banners");

                entity.HasIndex(e => e.Slug, "Banners_slug_unique")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Condition)
                    .IsRequired()
                    .HasColumnType("enum('banner','promo')")
                    .HasColumnName("condition")
                    .HasDefaultValueSql("'banner'")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Description)
                    .HasColumnType("text")
                    .HasColumnName("description")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Photo)
                    .HasColumnType("varchar(191)")
                    .HasColumnName("photo")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Slug)
                    .IsRequired()
                    .HasColumnType("varchar(191)")
                    .HasColumnName("slug")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnType("varchar(191)")
                    .HasColumnName("title")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");
            });

            modelBuilder.Entity<Brand>(entity =>
            {
                entity.ToTable("brands");

                entity.HasIndex(e => e.Slug, "Brands_slug_unique")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Slug)
                    .IsRequired()
                    .HasColumnType("varchar(191)")
                    .HasColumnName("slug")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnType("enum('active','inactive')")
                    .HasColumnName("status")
                    .HasDefaultValueSql("'active'")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnType("varchar(191)")
                    .HasColumnName("title")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");
            });

            modelBuilder.Entity<Cart>(entity =>
            {
                entity.ToTable("carts");

                entity.HasIndex(e => e.OrderId, "Carts_order_id_foreign");

                entity.HasIndex(e => e.ProductId, "Carts_product_id_foreign");

                entity.HasIndex(e => e.UserId, "Carts_user_id_foreign");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Amount)
                    .HasPrecision(10)
                    .HasColumnName("amount");

                entity.Property(e => e.OrderId)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("order_id");

                entity.Property(e => e.Price)
                    .HasPrecision(10)
                    .HasColumnName("price");

                entity.Property(e => e.ProductId)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("product_id");

                entity.Property(e => e.Quantity)
                    .HasColumnType("int(11)")
                    .HasColumnName("quantity");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnType("enum('new','progress','delivered','cancel')")
                    .HasColumnName("status")
                    .HasDefaultValueSql("'new'")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.UserId)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("user_id");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Carts)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("Carts_order_id_foreign");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Carts)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("Carts_product_id_foreign");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Carts)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("Carts_user_id_foreign");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("categories");

                entity.HasIndex(e => e.AddedBy, "Categories_added_by_foreign");

                entity.HasIndex(e => e.ParentId, "Categories_parent_id_foreign");

                entity.HasIndex(e => e.Slug, "Categories_slug_unique")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.AddedBy)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("added_by");

                entity.Property(e => e.IsParent)
                    .IsRequired()
                    .HasColumnName("is_parent")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.ParentId)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("parent_id");

                entity.Property(e => e.Photo)
                    .HasColumnType("varchar(191)")
                    .HasColumnName("photo")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Slug)
                    .IsRequired()
                    .HasColumnType("varchar(191)")
                    .HasColumnName("slug")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnType("enum('active','inactive')")
                    .HasColumnName("status")
                    .HasDefaultValueSql("'inactive'")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Summary)
                    .HasColumnType("text")
                    .HasColumnName("summary")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnType("varchar(191)")
                    .HasColumnName("title")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.HasOne(d => d.AddedByNavigation)
                    .WithMany(p => p.Categories)
                    .HasForeignKey(d => d.AddedBy)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("Categories_added_by_foreign");

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.InverseParent)
                    .HasForeignKey(d => d.ParentId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("Categories_parent_id_foreign");
            });

            modelBuilder.Entity<Coupon>(entity =>
            {
                entity.ToTable("coupons");

                entity.HasIndex(e => e.Code, "Coupons_code_unique")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasColumnType("varchar(191)")
                    .HasColumnName("code")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.EndedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("ended_at");

                entity.Property(e => e.IsVoucher).HasColumnName("is_voucher");

                entity.Property(e => e.Quantity)
                    .HasColumnType("int(11)")
                    .HasColumnName("quantity");

                entity.Property(e => e.StartedAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("started_at");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnType("enum('active','inactive')")
                    .HasColumnName("status")
                    .HasDefaultValueSql("'active'")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnType("enum('fixed','percent')")
                    .HasColumnName("type")
                    .HasDefaultValueSql("'fixed'")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Value)
                    .HasPrecision(20, 2)
                    .HasColumnName("value");
            });

            modelBuilder.Entity<Message>(entity =>
            {
                entity.ToTable("messages");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnType("varchar(191)")
                    .HasColumnName("email")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Message1)
                    .IsRequired()
                    .HasColumnType("longtext")
                    .HasColumnName("message")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(191)")
                    .HasColumnName("name")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Phone)
                    .HasColumnType("varchar(191)")
                    .HasColumnName("phone")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Photo)
                    .HasColumnType("varchar(191)")
                    .HasColumnName("photo")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.ReadAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("read_at");

                entity.Property(e => e.Subject)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("subject")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");
            });

            modelBuilder.Entity<Notification>(entity =>
            {
                entity.ToTable("notifications");

                entity.HasIndex(e => new { e.NotifiableType, e.NotifiableId }, "Notifications_notifiable_type_notifiable_id_index");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Data)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("data")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.NotifiableId)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("notifiable_id");

                entity.Property(e => e.NotifiableType)
                    .IsRequired()
                    .HasColumnType("varchar(191)")
                    .HasColumnName("notifiable_type")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.ReadAt)
                    .HasColumnType("timestamp")
                    .HasColumnName("read_at");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnType("varchar(191)")
                    .HasColumnName("type")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("orders");

                entity.HasIndex(e => e.CouponId, "Orders_coupon_id_foreign");

                entity.HasIndex(e => e.OrderNumber, "Orders_order_number_unique")
                    .IsUnique();

                entity.HasIndex(e => e.ProductId, "Orders_product_id_foreign");

                entity.HasIndex(e => e.ShippingId, "Orders_shipping_id_foreign");

                entity.HasIndex(e => e.UserId, "Orders_user_id_foreign");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("address")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.CouponId)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("coupon_id");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnType("varchar(191)")
                    .HasColumnName("email")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnType("varchar(191)")
                    .HasColumnName("first_name")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnType("varchar(191)")
                    .HasColumnName("last_name")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.OrderNumber)
                    .IsRequired()
                    .HasColumnType("varchar(191)")
                    .HasColumnName("order_number")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.PaymentMethod)
                    .IsRequired()
                    .HasColumnType("enum('cod','paypal')")
                    .HasColumnName("payment_method")
                    .HasDefaultValueSql("'cod'")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.PaymentStatus)
                    .IsRequired()
                    .HasColumnType("enum('paid','unpaid')")
                    .HasColumnName("payment_status")
                    .HasDefaultValueSql("'unpaid'")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasColumnType("varchar(191)")
                    .HasColumnName("phone")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.ProductId)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("product_id");

                entity.Property(e => e.Quantity)
                    .HasColumnType("int(11)")
                    .HasColumnName("quantity");

                entity.Property(e => e.ShippingId)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("shipping_id");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnType("enum('new','process','delivered','cancel')")
                    .HasColumnName("status")
                    .HasDefaultValueSql("'new'")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.SubTotal)
                    .HasPrecision(10)
                    .HasColumnName("sub_total");

                entity.Property(e => e.TotalAmount)
                    .HasPrecision(10)
                    .HasColumnName("total_amount");

                entity.Property(e => e.UserId)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("user_id");

                entity.HasOne(d => d.Coupon)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CouponId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("Orders_coupon_id_foreign");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("Orders_product_id_foreign");

                entity.HasOne(d => d.Shipping)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.ShippingId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("Orders_shipping_id_foreign");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("Orders_user_id_foreign");
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.ToTable("posts");

                entity.HasIndex(e => e.AddedBy, "Posts_added_by_foreign");

                entity.HasIndex(e => e.PostCatId, "Posts_post_cat_id_foreign");

                entity.HasIndex(e => e.Slug, "Posts_slug_unique")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.AddedBy)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("added_by");

                entity.Property(e => e.Description)
                    .HasColumnType("longtext")
                    .HasColumnName("description")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Photo)
                    .HasColumnType("varchar(191)")
                    .HasColumnName("photo")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.PostCatId)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("post_cat_id");

                entity.Property(e => e.Quote)
                    .HasColumnType("text")
                    .HasColumnName("quote")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Slug)
                    .IsRequired()
                    .HasColumnType("varchar(191)")
                    .HasColumnName("slug")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnType("enum('active','inactive')")
                    .HasColumnName("status")
                    .HasDefaultValueSql("'active'")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Summary)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("summary")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnType("varchar(191)")
                    .HasColumnName("title")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.HasOne(d => d.AddedByNavigation)
                    .WithMany(p => p.Posts)
                    .HasForeignKey(d => d.AddedBy)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("Posts_added_by_foreign");

                entity.HasOne(d => d.PostCat)
                    .WithMany(p => p.Posts)
                    .HasForeignKey(d => d.PostCatId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("Posts_post_cat_id_foreign");
            });

            modelBuilder.Entity<Postcategory>(entity =>
            {
                entity.ToTable("postcategories");

                entity.HasIndex(e => e.Slug, "PostCategories_slug_unique")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Slug)
                    .IsRequired()
                    .HasColumnType("varchar(191)")
                    .HasColumnName("slug")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnType("enum('active','inactive')")
                    .HasColumnName("status")
                    .HasDefaultValueSql("'active'")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnType("varchar(191)")
                    .HasColumnName("title")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");
            });

            modelBuilder.Entity<Postcomment>(entity =>
            {
                entity.ToTable("postcomments");

                entity.HasIndex(e => e.PostId, "PostComments_post_id_foreign");

                entity.HasIndex(e => e.UserId, "PostComments_user_id_foreign");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Comments)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("comments")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.ParentId)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("parent_id");

                entity.Property(e => e.PostId)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("post_id");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnType("enum('active','inactive')")
                    .HasColumnName("status")
                    .HasDefaultValueSql("'active'")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.UserId)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("user_id");

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.Postcomments)
                    .HasForeignKey(d => d.PostId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("PostComments_post_id_foreign");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Postcomments)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("PostComments_user_id_foreign");
            });

            modelBuilder.Entity<Postsandtag>(entity =>
            {
                entity.ToTable("postsandtags");

                entity.HasIndex(e => e.PostId, "PostsAndTags_post_id_foreign");

                entity.HasIndex(e => e.TagId, "PostsAndTags_post_tag_id_foreign");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.PostId)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("post_id");

                entity.Property(e => e.TagId)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("tag_id");

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.Postsandtags)
                    .HasForeignKey(d => d.PostId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("PostsAndTags_post_id_foreign");

                entity.HasOne(d => d.Tag)
                    .WithMany(p => p.Postsandtags)
                    .HasForeignKey(d => d.TagId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("PostsAndTags_post_tag_id_foreign");
            });

            modelBuilder.Entity<Posttag>(entity =>
            {
                entity.ToTable("posttags");

                entity.HasIndex(e => e.Slug, "PostTags_slug_unique")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Slug)
                    .IsRequired()
                    .HasColumnType("varchar(191)")
                    .HasColumnName("slug")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnType("enum('active','inactive')")
                    .HasColumnName("status")
                    .HasDefaultValueSql("'active'")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnType("varchar(191)")
                    .HasColumnName("title")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("products");

                entity.HasIndex(e => e.BrandId, "Products_brand_id_foreign");

                entity.HasIndex(e => e.CatId, "Products_cat_id_foreign");

                entity.HasIndex(e => e.ChildCatId, "Products_child_cat_id_foreign");

                entity.HasIndex(e => e.CouponId, "Products_coupon_id_foreign");

                entity.HasIndex(e => e.Slug, "Products_slug_unique")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.BrandId)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("brand_id");

                entity.Property(e => e.CatId)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("cat_id");

                entity.Property(e => e.ChildCatId)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("child_cat_id");

                entity.Property(e => e.Condition)
                    .IsRequired()
                    .HasColumnType("enum('default','new','hot')")
                    .HasColumnName("condition")
                    .HasDefaultValueSql("'default'")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.CouponId)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("coupon_id");

                entity.Property(e => e.Description)
                    .HasColumnType("longtext")
                    .HasColumnName("description")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Photo1)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("photo1")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Photo2)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("photo2")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Photo3)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("photo3")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Photo4)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("photo4")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Price)
                    .HasPrecision(10)
                    .HasColumnName("price");

                entity.Property(e => e.Slug)
                    .IsRequired()
                    .HasColumnType("varchar(191)")
                    .HasColumnName("slug")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnType("enum('active','inactive')")
                    .HasColumnName("status")
                    .HasDefaultValueSql("'inactive'")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Stock)
                    .HasColumnType("int(11)")
                    .HasColumnName("stock")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Summary)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("summary")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnType("varchar(191)")
                    .HasColumnName("title")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.HasOne(d => d.Brand)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.BrandId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("Products_brand_id_foreign");

                entity.HasOne(d => d.Cat)
                    .WithMany(p => p.ProductCats)
                    .HasForeignKey(d => d.CatId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("Products_cat_id_foreign");

                entity.HasOne(d => d.ChildCat)
                    .WithMany(p => p.ProductChildCats)
                    .HasForeignKey(d => d.ChildCatId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("Products_child_cat_id_foreign");

                entity.HasOne(d => d.Coupon)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CouponId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("Products_coupon_id_foreign");
            });

            modelBuilder.Entity<Productattribute>(entity =>
            {
                entity.ToTable("productattributes");

                entity.HasIndex(e => e.ProductId, "ProductAttributes_product_id_foreign");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Color)
                    .IsRequired()
                    .HasColumnType("varchar(191)")
                    .HasColumnName("color")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Price)
                    .HasPrecision(10)
                    .HasColumnName("price");

                entity.Property(e => e.ProductId)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("product_id");

                entity.Property(e => e.Stock)
                    .HasColumnType("int(11)")
                    .HasColumnName("stock")
                    .HasDefaultValueSql("'1'");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Productattributes)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("ProductAttributes_product_id_foreign");
            });

            modelBuilder.Entity<Productreview>(entity =>
            {
                entity.ToTable("productreviews");

                entity.HasIndex(e => e.ProductId, "ProductReviews_product_id_foreign");

                entity.HasIndex(e => e.UserId, "ProductReviews_user_id_foreign");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.ProductId)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("product_id");

                entity.Property(e => e.Rating)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("rating");

                entity.Property(e => e.Review)
                    .HasColumnType("text")
                    .HasColumnName("review")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnType("enum('active','inactive')")
                    .HasColumnName("status")
                    .HasDefaultValueSql("'active'")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.UserId)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("user_id");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Productreviews)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("ProductReviews_product_id_foreign");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Productreviews)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("ProductReviews_user_id_foreign");
            });

            modelBuilder.Entity<Setting>(entity =>
            {
                entity.ToTable("settings");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasColumnType("varchar(191)")
                    .HasColumnName("address")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnType("longtext")
                    .HasColumnName("description")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnType("varchar(191)")
                    .HasColumnName("email")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Logo)
                    .IsRequired()
                    .HasColumnType("varchar(191)")
                    .HasColumnName("logo")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasColumnType("varchar(191)")
                    .HasColumnName("phone")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Photo)
                    .IsRequired()
                    .HasColumnType("varchar(191)")
                    .HasColumnName("photo")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.ShortDes)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("short_des")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");
            });

            modelBuilder.Entity<Shipping>(entity =>
            {
                entity.ToTable("shippings");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Price)
                    .HasPrecision(8, 2)
                    .HasColumnName("price");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnType("enum('active','inactive')")
                    .HasColumnName("status")
                    .HasDefaultValueSql("'active'")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnType("varchar(191)")
                    .HasColumnName("type")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.HasIndex(e => e.Email, "Users_email_unique")
                    .IsUnique();

                entity.HasIndex(e => e.Phone, "Users_phone_unique")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Address)
                    .HasColumnType("varchar(191)")
                    .HasColumnName("address")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Email)
                    .HasColumnType("varchar(191)")
                    .HasColumnName("email")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Fullname)
                    .IsRequired()
                    .HasColumnType("varchar(191)")
                    .HasColumnName("fullname")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Password)
                    .HasColumnType("varchar(191)")
                    .HasColumnName("password")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Phone)
                    .HasColumnType("varchar(191)")
                    .HasColumnName("phone")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Photo)
                    .HasColumnType("varchar(191)")
                    .HasColumnName("photo")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Role)
                    .IsRequired()
                    .HasColumnType("enum('employee','customer')")
                    .HasColumnName("role")
                    .HasDefaultValueSql("'customer'")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnType("enum('active','inactive')")
                    .HasColumnName("status")
                    .HasDefaultValueSql("'active'")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasColumnType("varchar(191)")
                    .HasColumnName("user_name")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");
            });

            modelBuilder.Entity<Wishlist>(entity =>
            {
                entity.ToTable("wishlists");

                entity.HasIndex(e => e.CartId, "Wishlists_cart_id_foreign");

                entity.HasIndex(e => e.ProductId, "Wishlists_product_id_foreign");

                entity.HasIndex(e => e.UserId, "Wishlists_user_id_foreign");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Amount)
                    .HasPrecision(10)
                    .HasColumnName("amount");

                entity.Property(e => e.CartId)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("cart_id");

                entity.Property(e => e.Color)
                    .IsRequired()
                    .HasColumnType("varchar(191)")
                    .HasColumnName("color")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Price)
                    .HasPrecision(10)
                    .HasColumnName("price");

                entity.Property(e => e.ProductId)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("product_id");

                entity.Property(e => e.Quantity)
                    .HasColumnType("int(11)")
                    .HasColumnName("quantity");

                entity.Property(e => e.UserId)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("user_id");

                entity.HasOne(d => d.Cart)
                    .WithMany(p => p.Wishlists)
                    .HasForeignKey(d => d.CartId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("Wishlists_cart_id_foreign");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Wishlists)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("Wishlists_product_id_foreign");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Wishlists)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("Wishlists_user_id_foreign");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
