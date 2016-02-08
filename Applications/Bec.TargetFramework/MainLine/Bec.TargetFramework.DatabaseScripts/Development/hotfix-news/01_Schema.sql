CREATE TABLE public."NewsArticle" (
  "NewsArticleID" uuid NOT NULL UNIQUE,
  "Title" text NOT NULL,
  "DateTime" TIMESTAMP WITH TIME ZONE NOT NULL,
  "Content" text NOT NULL
) ;