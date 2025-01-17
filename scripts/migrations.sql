CREATE TABLE IF NOT EXISTS public."__EFMigrationsHistory" (
    migration_id character varying(150) NOT NULL,
    product_version character varying(32) NOT NULL,
    CONSTRAINT pk___ef_migrations_history PRIMARY KEY (migration_id)
);

START TRANSACTION;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM public."__EFMigrationsHistory" WHERE "migration_id" = '20250115155813_IntialMigrations') THEN
    CREATE TABLE public."user" (
        id uuid NOT NULL,
        name character varying(100) NOT NULL,
        last_name character varying(100) NOT NULL,
        email character varying(255) NOT NULL,
        created_at timestamptz NOT NULL DEFAULT (CURRENT_TIMESTAMP),
        updated_at timestamptz DEFAULT (CURRENT_TIMESTAMP),
        is_active boolean NOT NULL DEFAULT TRUE,
        CONSTRAINT pk_user PRIMARY KEY (id)
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM public."__EFMigrationsHistory" WHERE "migration_id" = '20250115155813_IntialMigrations') THEN
    CREATE TABLE public.account (
        id uuid NOT NULL,
        balance numeric(18,2) NOT NULL,
        account_number character varying(255) NOT NULL,
        user_id uuid NOT NULL,
        created_at timestamptz NOT NULL DEFAULT (CURRENT_TIMESTAMP),
        updated_at timestamptz DEFAULT (CURRENT_TIMESTAMP),
        is_active boolean NOT NULL DEFAULT TRUE,
        CONSTRAINT pk_account PRIMARY KEY (id),
        CONSTRAINT fk_account_user_user_id FOREIGN KEY (user_id) REFERENCES public."user" (id) ON DELETE CASCADE
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM public."__EFMigrationsHistory" WHERE "migration_id" = '20250115155813_IntialMigrations') THEN
    CREATE UNIQUE INDEX ix_account_account_number ON public.account (account_number);
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM public."__EFMigrationsHistory" WHERE "migration_id" = '20250115155813_IntialMigrations') THEN
    CREATE INDEX ix_account_user_id ON public.account (user_id);
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM public."__EFMigrationsHistory" WHERE "migration_id" = '20250115155813_IntialMigrations') THEN
    CREATE UNIQUE INDEX ix_user_email ON public."user" (email);
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM public."__EFMigrationsHistory" WHERE "migration_id" = '20250115155813_IntialMigrations') THEN
    INSERT INTO public."__EFMigrationsHistory" (migration_id, product_version)
    VALUES ('20250115155813_IntialMigrations', '9.0.0');
    END IF;
END $EF$;
COMMIT;

