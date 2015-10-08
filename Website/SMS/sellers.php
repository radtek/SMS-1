<?php $thisPage="sellers"; ?>
<?php include 'header-products.php'; ?>
<script>
$(document).ready(function(){
    $(".expand1").click(function(){
        $(".show1").slideToggle();
    });
});
</script>
<script>
$(document).ready(function(){
    $(".expand1").click(function(){
        $(".expand1").toggleClass("min");
    });
});
</script>
<script>
$(document).ready(function(){
    $(".expand1").click(function(){
        $(".min1").slideToggle();
    });
});
</script>
<script>
$(document).ready(function(){
    $(".min1").click(function(){
        $("expand1").slideToggle();
    });
});
</script>

<script>
$(document).ready(function(){
    $(".expand2").click(function(){
        $(".show2").slideToggle();
    });
});
</script>
<script>
$(document).ready(function(){
    $(".expand2").click(function(){
        $(".expand2").toggleClass("min");
    });
});
</script>

<script>
$(document).ready(function(){
    $(".expand3").click(function(){
        $(".show3").slideToggle();
    });
});
</script>
<script>
$(document).ready(function(){
    $(".expand3").click(function(){
        $(".expand3").toggleClass("min");
    });
});
</script>

<!-- Primary Page Layout
–––––––––––––––––––––––––––––––––––––––––––––––––– -->
<div class="container buyers subPage">
	<div class="row">
		<div class="seven columns">
			<h1>Safe Seller Specification</h1>
			<div>
				<p class="expand1">Risk Management Features <span>[Click to Expand]</span></p>
				<ul class="show1">
					<li><span>The seller's conveyancer can check that the bank account details provided by the seller belong to the registered proprietor of the property that has been sold - so the conveyancer can transfer money with low risk</span></li>
					<li><span>The seller's conveyancer can check that the bank account details provided by additional sellers to ensure they belong to the registered proprietor of the property that has been sold - so the conveyancer can transfer money with low risk</span></li>
					<li><span>The seller is issued with a fraud insurance policy (Standard & Poors rated A+) - so if a fraud occurs despite the above checks the seller is financially protected against losing their deposit</span></li>
				</ul>

				<p class="expand2">Insurance Features <span>[Click to Expand]</span></p>
				<ul class="show2">
					<li><span>The conveyancing firm is added as an insured party to the buyer's insurance policy - so the conveyancing firm's exposure to financial loss is completely protected from these fraud risks and their PII is safeguarded</span></li>
					<li><span>Additional sellers are added as insured parties to the seller's insurance policy - so their money is completely protected from these fraud risks</span></li>
				</ul>


				<p class="expand3">Safe Move Scheme Benefits <span>[Click to Expand]</span></p>
				<ul class="show3">
					<li><span>The SMS gives lenders and conveyancers a customer outcomes control system to meet FCA and SRA anti-fraud requirements</span></li>
					<li><span>How do you know where incoming funds transferred to your client account really come from? Who owns these bank accounts? The SMS provides a full validated money flow audit trail for new AML regulations</span></li>
					<li><span>The SMS detects when unauthorised conveyancing firms/bogus firms are involved in your transactions</span></li>
					<li><span>Free to use for conveyancers, lenders, mortgage brokers and estate agents</span></li>
					<li><span>Lender integration available - the SMS is already sharing data with lenders</span></li>
					<li><span>Stringently built and maintained to ISO27001 data security standards</span></li>
				</ul>
			</div>
		</div>
		<div class="five columns">
			<img src="images/tape-measure-icon.png" alt="BE Consultancy Business Services" title="BE Consultancy Business Services">
		</div>
	</div>
</div>
<?php include 'sponsors.php'; ?>

<!-- End Document
–––––––––––––––––––––––––––––––––––––––––––––––––– -->
<?php include 'footer.php'; ?>