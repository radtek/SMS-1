CREATE TABLE public."NewsArticle" (
  "NewsArticleID" uuid NOT NULL UNIQUE,
  "Title" text NOT NULL,
  "DateTime" TIMESTAMP WITH TIME ZONE NOT NULL,
  "Content" text NOT NULL
);

grant select, insert, update, delete on public."NewsArticle" to bef;
grant select, insert, update, delete on public."NewsArticle" to postgres;
) ;


insert into "NewsArticle" values (uuid_generate_v1(), 'The Safe Move Scheme Reports Shocking New Figures Highlighting Buyer Deposit Redirection Fraud', '2016/01/08', 'The extent of frauds where property buyers are duped into transferring money to criminals has been exposed by the Safe Move Scheme, for the first time, following their request to the City of London Police, to provide accurate data, collated across England and Wales, to reveal the extent of this specific type of fraud. The report shows a dramatic escalation since the first case recorded that can be identified as affecting the conveyance market in July 2013. These figures show that the period between July 2013 and July 2014 saw an average of 1 case reported every 2 months, however in September 2015 (the last month in the latest data set) there were 9 reported cases, representing an 1800% increase. The average loss from buyer deposit redirection fraud is £112,310 and the total losses add up to £10,220,275 from 91 reported cases. 
DCI Jason Tunn, Head of the Metropolitan Police Cyber Crime Unit announced "The MPS (Metropolitan Police Service) welcomes private industry highlighting crime figures that specifically affect the mortgage and conveyancing market place, which have been contained within ‘mandate fraud’ figures until now. These figures demonstrate a rising crime trend that all stake holders should be made aware of and will assist the public with realising that they may be duped into sending their hard saved money for property deposits to criminals rather than the solicitors. Developing strategies and products with industry stakeholders to prevent these crimes occurring is the way forward, and the MPS Falcon teams are responding to these threats in order to prevent and detect offences" 
Ed Powell, from BE Consultancy, the creators of the Safe Move Scheme, commented “The Safe Buyer product protects buyers from transferring their purchase deposit money to criminals, a growing problem highlighted in recent high profile cases involving some very well respected and specialist conveyancing firms and validated by the City of London Police crime figures. With 9 cases in September 2015 at an average loss of £112,000 this problem is causing significant harm to lender’s and conveyancer’s customers and is a major threat to every conveyancing businesses.”
');

insert into "NewsArticle" values (uuid_generate_v1(), 'Paragon Selects The Safe Move Scheme to Protect Their Clients From Fraud', '2016/01/13', 'Paragon Mortgages (or Mortgage Trust as they are also known as) has become the first Lender to protect their customers from Fraud using the Safe Move Scheme.
In an official statement to their conveyancing panel Paragon announced “Paragon has assessed available tools that help reduce the risk to our customers and we now require all our panel conveyancing firms to register with the Safe Move Scheme and use the Safe Buyer product which allows our customers, before they transfer money to their conveyancing firm, to verify the bank account details that they have received are genuine. This will significantly reduce the risk of our customers sending money to a bogus conveyancing firm.” 
Paragon added “Our customers are at the heart of everything we do and we are committed to protecting them against this type of crime. We have already asked our panel of conveyancers to register with the Safe Move Scheme so our customers can use the bank validation service. We''re also pleased to announce that we will be funding the cost of Safe Buyer so all our customers can check their conveyancing firm’s bank account details at no cost to them.”
This move comes as a result of lengthy development and testing of the Safe Move Scheme in collaboration with several lenders who are obliged to protect their customers from fraud.
');

insert into "NewsArticle" values (uuid_generate_v1(), 'Professional Indemnity Insurer Withdraws From Market Over Growing Cybercrime Threat', '2016/02/04', 'Elite Insurance, a professional indemnity insurer, today announced it is pulling out of the solicitors PI market.
Elite blamed the increased likelihood of fraud involving client accounts, as a significant factor its decision to withdraw.
Elite are amongst the largest 15 PI insurers for solicitor’s indemnity in the market and have announced that they will not be writing new policies or offering renewal terms to their existing clients.
Chief executive Jason Smart commented ‘We have seen an increasing number of such attacks and feel these are not likely to abate. The risk is beyond the control of our underwriting team.’
Elite’s position is the first public acknowledgement by an insurer of the dangers of client account fraud faced by conveyancers.
');

insert into "NewsArticle" values (uuid_generate_v1(), 'The Safe Move Scheme Reports Fraud Prevention Case', '2016/02/08', 'The Safe Move Scheme, a product developed by BE Consultancy to prevent property buyers having their deposits fraudulently redirected into the hands of criminals is pleased to report its first prevention.
RG Solicitors are a member of The Safe Move Scheme, and one of their clients who had received appropriate professional advice opted to use the Safe Move Scheme as “best practice” in their property purchase.
The client received email instructions to transfer their deposit to RG Solicitors. The instructions appeared to be genuine. Prior to transferring the funds, the client submitted the banking details from the conveyancers apparent instructions to The Safe Move Scheme, in order to verify their authenticity. The Safe Move Scheme advised to decline these instructions as the details did not match those of RG Solicitors.
The Safe Move Scheme provides a live alert system so that all the parties concerned, from the purchaser right through to the lender are aware that a fraudulent attempt to divert funds has been made.
Matt Gillies, the managing partner of RG Solicitors, said “Whilst we provide every possible level of security, we know from The Safe Move Scheme that hackers actually attack our client’s emails and devices rather than our systems. We are extremely proud to be the first conveyancers to prevent one of these crimes occurring using The Safe Move Scheme and we will continue to recommend it to all of our clients as the proven benchmark for preventing this type of crime”.
The Safe Move Scheme has reported this attempted fraud to Action Fraud.
');