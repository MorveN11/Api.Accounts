CREATE TABLE IF NOT EXISTS public."__EFMigrationsHistory" (
    migration_id character varying(150) NOT NULL,
    product_version character varying(32) NOT NULL,
    CONSTRAINT pk___ef_migrations_history PRIMARY KEY (migration_id)
);

START TRANSACTION;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM public."__EFMigrationsHistory" WHERE "migration_id" = '20250117121125_IntialMigrations') THEN
    CREATE TABLE public.users (
        id uuid NOT NULL,
        name character varying(100),
        pic text NOT NULL,
        pic_path text NOT NULL,
        created_at timestamptz NOT NULL DEFAULT (CURRENT_TIMESTAMP),
        updated_at timestamptz DEFAULT (CURRENT_TIMESTAMP),
        is_active boolean NOT NULL DEFAULT TRUE,
        CONSTRAINT pk_users PRIMARY KEY (id)
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM public."__EFMigrationsHistory" WHERE "migration_id" = '20250117121125_IntialMigrations') THEN
    CREATE TABLE public.accounts (
        id uuid NOT NULL,
        balance numeric(18,2) NOT NULL,
        user_id uuid NOT NULL,
        created_at timestamptz NOT NULL DEFAULT (CURRENT_TIMESTAMP),
        updated_at timestamptz DEFAULT (CURRENT_TIMESTAMP),
        is_active boolean NOT NULL DEFAULT TRUE,
        CONSTRAINT pk_accounts PRIMARY KEY (id),
        CONSTRAINT fk_accounts_users_user_id FOREIGN KEY (user_id) REFERENCES public.users (id) ON DELETE CASCADE
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM public."__EFMigrationsHistory" WHERE "migration_id" = '20250117121125_IntialMigrations') THEN
    CREATE INDEX ix_accounts_user_id ON public.accounts (user_id);
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM public."__EFMigrationsHistory" WHERE "migration_id" = '20250117121125_IntialMigrations') THEN
    INSERT INTO public."__EFMigrationsHistory" (migration_id, product_version)
    VALUES ('20250117121125_IntialMigrations', '9.0.0');
    END IF;
END $EF$;
COMMIT;

