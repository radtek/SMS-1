<?php $thisPage="buyer"; ?>
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
			<h1>Safe Buyer Specification</h1>
			<div>
				<p class="expand1">Risk Management Features <span>[Click to Expand]</span></p>
				<ul class="show1">
					<li><span>The buyer can check that the bank account details provided by his/her conveyancer belong to that conveyancing firm - so the buyer can transfer 					money with low risk</span></li>
					<!--
<li><span>The buyer's conveyancer can check that the bank account details provided by the seller's conveyancer belong to that conveyancing firm - so the 					buyer's conveyancer can transfer money with low risk</span></li>
					<li><span>The buyer's conveyancer can check the identity of the seller compared to the owner on the HMLR records - so the buyer's conveyancer can confirm 					that the seller is the registered proprietor as part of their Certificate of Title obligations when confirming that the property is being sold with 'Good 					Title'</span></li>
-->
					<li><span>Additional buyers and giftors' (people gifting deposits to the buyer/s) can also check that the bank account details provided by his/her 							conveyancer belong to that conveyancing firm - so the additional buyer/s or giftors' can transfer money with low risk</span></li>
					<li><span>Comply with the latest AML regulations by proving that you know who owns the bank account that deposit money has come from.</span></li>
				</ul>
				<!--
<p class="expand2">Insurance Features <span>[Click to Expand]</span></p>
				<ul class="show2">
					<li><span>The buyer is issued with a fraud insurance policy (Standard & Poors rated A+) that insures up to 120% of the purchase price - so if a fraud occurs despite the above checks the buyer is financially protected against losing their deposit, redeeming their new mortgage and their transaction costs e.g. conveyancing, mortgage arrangement fees etc</span></li>
					<li><span>The lender is added as an insured party to the buyer's insurance policy - so the lender's money is completely protected from these fraud risks</span></li>
					<li><span>The conveyancing firm is added as an insured party to the buyer's insurance policy - so the conveyancing firm's exposure to financial loss is completely protected from these fraud risks and their PII is safeguarded</span></li>
					<li><span>Additional buyers/giftors are added as insured parties to the buyer's insurance policy - so their money is completely protected from these fraud risks</span></li>
				</ul>
-->
				<p class="expand3">Safe Move Scheme Benefits <span>[Click to Expand]</span></p>
				<ul class="show3">
					<li><span>The SMS gives lenders and conveyancers a customer outcomes control system to meet FCA and SRA anti-fraud requirements </span></li>
					<li><span>How do you know where incoming funds transferred to your client account really come from? Who owns these bank accounts? The SMS provides a full validated money flow audit trail for new AML regulations</span></li>
					<li><span>The SMS detects when unauthorised conveyancing firms/bogus firms are involved in your transactions</span></li>
					<li><span>Free to use for conveyancers, lenders, mortgage brokers and estate agents</span></li>
					<li><span>Lender integration available - the SMS is already sharing data with lenders</span></li>
					<li><span>Stringently built and maintained to ISO27001 data security standards</span></li>
				</ul>

			</div>
		</div>
		<div class="five columns">
			<img src="images/Safemove-Icon.png" alt="Safe Move Scheme Safe Buyers" title="Safe Move Scheme Safe Buyers">
		</div>
	</div>
</div>
<?php include 'sponsors.php'; ?>

<!-- End Document
–––––––––––––––––––––––––––––––––––––––––––––––––– -->
<?php include 'footer.php'; ?>