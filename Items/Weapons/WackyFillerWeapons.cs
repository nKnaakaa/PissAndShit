using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

//haha all in one file goes brrrrrr

namespace PissAndShit.Items.Weapons;

public class DynamiteSord : ModItem
{
    public override void SetStaticDefaults() {
        DisplayName.SetDefault("Dynamite of the Gods");
    }

    public override void SetDefaults() {
        Item.damage = 1;
        Item.DamageType = DamageClass.Melee /* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
        Item.width = 56;
        Item.height = 56;
        Item.noMelee = true;
        Item.useTime = 10;
        Item.useAnimation = 10;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.rare = -12;
        Item.autoReuse = true;
        Item.shoot = ProjectileID.Dynamite;
        Item.UseSound = SoundID.Item1;
        Item.shootSpeed = 19f;
    }

    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
        float numProj = 5;
        float rotation = MathHelper.ToRadians(15);
        float speedX = velocity.X;
        float speedY = velocity.Y;
        float knockBack = knockback;
        position += Vector2.Normalize(new Vector2(speedX, speedY)) * 45f;
        for (int i = 0; i < numProj; i++) {
            var pertSpeed = new Vector2(speedX, speedY).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numProj - 1))); // * .7f
            Projectile.NewProjectile(source, position.X, position.Y, pertSpeed.X, pertSpeed.Y, type, damage, knockBack, player.whoAmI);
        }

        return false;
    }

    public override void AddRecipes() {
        var recipe = CreateRecipe();
        recipe.AddIngredient(ItemID.Dynamite, 666);
        recipe.AddTile(TileID.MythrilAnvil);
        recipe.Register();
    }
}

public class TombstoneLauncher : ModItem
{
    public override void SetStaticDefaults() {
        DisplayName.SetDefault("Tombstone Launcher");
    }

    public override void SetDefaults() {
        Item.damage = 1;
        Item.DamageType = DamageClass.Ranged;
        Item.width = 46;
        Item.height = 32;
        Item.noMelee = true;
        Item.useTime = 20;
        Item.useAnimation = 20;
        Item.useStyle = ItemUseStyleID.Shoot;
        Item.rare = -1;
        Item.autoReuse = true;
        Item.shoot = ProjectileID.Tombstone;
        Item.UseSound = SoundID.Item11;
        Item.shootSpeed = 9f;
    }

    public override void AddRecipes() {
        var recipe = CreateRecipe();
        recipe.AddIngredient(ItemID.Tombstone, 15);
        recipe.AddTile(TileID.Anvils);
        recipe.Register();
    }
}

public class tortle : ModItem
{
    public override void SetStaticDefaults() {
        DisplayName.SetDefault("Turtle Gun");
    }

    public override void SetDefaults() {
        Item.damage = 51;
        Item.DamageType = DamageClass.Ranged;
        Item.width = 32;
        Item.height = 24;
        Item.noMelee = true;
        Item.useTime = 15;
        Item.useAnimation = 15;
        Item.useStyle = ItemUseStyleID.Shoot;
        Item.rare = ItemRarityID.Lime;
        Item.autoReuse = true;
        Item.shoot = ModContent.ProjectileType<liltortle>();
        Item.UseSound = SoundID.Item11;
        Item.shootSpeed = 24f;
    }

    public override void AddRecipes() {
        var recipe = CreateRecipe();
        recipe.AddIngredient(ItemID.Handgun);
        recipe.AddIngredient(ItemID.TurtleShell);
        recipe.AddTile(TileID.MythrilAnvil);
        recipe.Register();
    }
}

public class liltortle : ModProjectile
{
    public override void SetStaticDefaults() {
        DisplayName.SetDefault("Turtle Shell");
    }

    public override void SetDefaults() {
        Projectile.width = 16;
        Projectile.height = 12;
        Projectile.aiStyle = 1;
        Projectile.friendly = true;
        Projectile.timeLeft = 360;
        Projectile.penetrate = 5;
        Projectile.tileCollide = true;
        Projectile.DamageType = DamageClass.Ranged;
    }

    public override bool OnTileCollide(Vector2 oldVelocity) {
        if (Projectile.velocity.X != oldVelocity.X) {
            Projectile.velocity.X = oldVelocity.X * -1f;
        }

        if (Projectile.velocity.Y != oldVelocity.Y) {
            Projectile.velocity.Y = oldVelocity.Y * -1f;
        }

        return false;
    }
}

public class HalfExistingTrident : ModItem
{
    public override void SetStaticDefaults() {
        Tooltip.SetDefault("Imagine clipping through reality");
    }

    public override void SetDefaults() {
        Item.damage = 45;
        Item.useStyle = ItemUseStyleID.Shoot;
        Item.useAnimation = 9;
        Item.useTime = 9;
        Item.shootSpeed = 3.7f;
        Item.knockBack = 6.5f;
        Item.width = 64;
        Item.height = 64;
        Item.scale = 0.5f;
        Item.rare = ItemRarityID.LightPurple;
        Item.value = Item.sellPrice(silver: 75);

        Item.DamageType = DamageClass.Melee /* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
        Item.noMelee = true; // Important because the spear is actually a projectile instead of an item. This prevents the melee hitbox of this item.
        Item.noUseGraphic = true; // Important, it's kind of wired if people see two spears at one time. This prevents the melee animation of this item.
        Item.autoReuse = true; // Most spears don't autoReuse, but it's possible when used in conjunction with CanUseItem()

        Item.UseSound = SoundID.Item1;
        Item.shoot = ModContent.ProjectileType<HalfExistingTridentProj>();
    }

    public override bool CanUseItem(Player player) {
        // Ensures no more than one spear can be thrown out, use this when using autoReuse
        return player.ownedProjectileCounts[Item.shoot] < 5;
    }

    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
        float numProj = 5;
        float rotation = MathHelper.ToRadians(35);
        float speedX = velocity.X;
        float speedY = velocity.Y;
        float knockBack = knockback;
        position += Vector2.Normalize(new Vector2(speedX, speedY)) * 45f;
        for (int i = 0; i < numProj; i++) {
            var pertSpeed = new Vector2(speedX, speedY).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numProj - 1))); // * .7f
            Projectile.NewProjectile(source, position.X, position.Y, pertSpeed.X, pertSpeed.Y, type, damage, knockBack, player.whoAmI);
        }

        return false;
    }

    public override void AddRecipes() {
        var recipe = CreateRecipe();
        recipe.AddIngredient(ItemID.SoulofLight, 15);
        recipe.AddIngredient(ItemID.SoulofNight, 15);
        recipe.AddTile(TileID.MythrilAnvil);
        recipe.Register();
    }
}

public class HalfExistingTridentProj : ModProjectile
{
    // In here the AI uses this example, to make the code more organized and readable
    // Also showcased in ExampleJavelinProjectile.cs
    public float movementFactor // Change this value to alter how fast the spear moves
    {
        get => Projectile.ai[0];
        set => Projectile.ai[0] = value;
    }

    public override void SetStaticDefaults() {
        DisplayName.SetDefault("Half Existing Trident");
    }

    public override void SetDefaults() {
        Projectile.width = 64;
        Projectile.height = 64;
        Projectile.scale = 0.5f;
        Projectile.aiStyle = 19;
        Projectile.penetrate = -1;
        Projectile.alpha = 0;

        Projectile.hide = true;
        Projectile.ownerHitCheck = true;
        Projectile.DamageType = DamageClass.Melee;
        Projectile.tileCollide = false;
        Projectile.friendly = true;
    }

    // It appears that for this AI, only the ai0 field is used!
    public override void AI() {
        // Since we access the owner player instance so much, it's useful to create a helper local variable for this
        // Sadly, Projectile/ModProjectile does not have its own
        var projOwner = Main.player[Projectile.owner];
        // Here we set some of the projectile's owner properties, such as held item and itemtime, along with projectile direction and position based on the player
        var ownerMountedCenter = projOwner.RotatedRelativePoint(projOwner.MountedCenter, true);
        Projectile.direction = projOwner.direction;
        projOwner.heldProj = Projectile.whoAmI;
        projOwner.itemTime = projOwner.itemAnimation;
        Projectile.position.X = ownerMountedCenter.X - Projectile.width / 2;
        Projectile.position.Y = ownerMountedCenter.Y - Projectile.height / 2;
        // As long as the player isn't frozen, the spear can move
        if (!projOwner.frozen) {
            if (movementFactor == 0f) // When initially thrown out, the ai0 will be 0f
            {
                movementFactor = 3f; // Make sure the spear moves forward when initially thrown out
                Projectile.netUpdate = true; // Make sure to netUpdate this spear
            }

            if (projOwner.itemAnimation < projOwner.itemAnimationMax / 3) // Somewhere along the item animation, make sure the spear moves back
            {
                movementFactor -= 4.7f;
            }
            else // Otherwise, increase the movement factor
            {
                movementFactor += 7.3f;
            }
        }

        // Change the spear position based off of the velocity and the movementFactor
        Projectile.position += Projectile.velocity * movementFactor;
        // When we reach the end of the animation, we can kill the spear projectile
        if (projOwner.itemAnimation == 0) {
            Projectile.Kill();
        }

        // Apply proper rotation, with an offset of 135 degrees due to the sprite's rotation, notice the usage of MathHelper, use this class!
        // MathHelper.ToRadians(xx degrees here)
        Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.ToRadians(158f);
        // Offset by 90 degrees here
        if (Projectile.spriteDirection == -1) {
            Projectile.rotation -= MathHelper.ToRadians(58f);
        }

        // Since we access the owner player instance so much, it's useful to create a helper local variable for this
        // Sadly, Projectile/ModProjectile does not have its own
        // Here we set some of the projectile's owner properties, such as held item and itemtime, along with projectile direction and position based on the player
        Projectile.direction = projOwner.direction;
        projOwner.heldProj = Projectile.whoAmI;
        projOwner.itemTime = projOwner.itemAnimation;
        Projectile.position.X = ownerMountedCenter.X - Projectile.width / 2;
        Projectile.position.Y = ownerMountedCenter.Y - Projectile.height / 2;
        // As long as the player isn't frozen, the spear can move
        if (!projOwner.frozen) {
            if (movementFactor == 0f) // When initially thrown out, the ai0 will be 0f
            {
                movementFactor = 3f; // Make sure the spear moves forward when initially thrown out
                Projectile.netUpdate = true; // Make sure to netUpdate this spear
            }

            if (projOwner.itemAnimation < projOwner.itemAnimationMax / 3) // Somewhere along the item animation, make sure the spear moves back
            {
                movementFactor -= 7.4f;
            }
            else // Otherwise, increase the movement factor
            {
                movementFactor += 3.7f;
            }
        }

        // Change the spear position based off of the velocity and the movementFactor
        Projectile.position += Projectile.velocity * movementFactor;
        // When we reach the end of the animation, we can kill the spear projectile
        if (projOwner.itemAnimation == 0) {
            Projectile.Kill();
        }

        // Apply proper rotation, with an offset of 135 degrees due to the sprite's rotation, notice the usage of MathHelper, use this class!
        // MathHelper.ToRadians(xx degrees here)
        Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.ToRadians(185f);
        // Offset by 90 degrees here
        if (Projectile.spriteDirection == -1) {
            Projectile.rotation -= MathHelper.ToRadians(85f);
        }
    }
}

public class AncientMonkys : ModItem
{
    public override void SetStaticDefaults() {
        DisplayName.SetDefault("Tome of the Ancient Monkys");
        Tooltip.SetDefault("Monky");
    }

    public override void SetDefaults() {
        Item.damage = 40;
        Item.DamageType = DamageClass.Magic;
        Item.width = 32;
        Item.height = 24;
        Item.noMelee = true;
        Item.useTime = 15;
        Item.useAnimation = 15;
        Item.useStyle = ItemUseStyleID.Shoot;
        Item.rare = ItemRarityID.Purple;
        Item.autoReuse = true;
        Item.mana = 10;
        Item.shoot = ProjectileID.BoneGloveProj;
        Item.UseSound = SoundID.Item8;
        Item.shootSpeed = 12f;
    }

    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
        float speedX = velocity.X;
        float speedY = velocity.Y;
        float knockBack = knockback;
        Projectile.NewProjectile(source, position.X, position.Y, speedX, speedY, ProjectileID.LovePotion, damage, knockBack, player.whoAmI);
        Projectile.NewProjectile(source, position.X, position.Y, speedX, speedY, ProjectileID.ShadowFlameKnife, damage, knockBack, player.whoAmI);
        Projectile.NewProjectile(source, position.X, position.Y, speedX, speedY, ProjectileID.SolarFlareRay, damage, knockBack, player.whoAmI);
        Projectile.NewProjectile(source, position.X, position.Y, speedX, speedY, ProjectileID.MonkStaffT2Ghast, damage, knockBack, player.whoAmI);
        Projectile.NewProjectile(source, position.X, position.Y, speedX, speedY, ProjectileID.TiedEighthNote, damage, knockBack, player.whoAmI);
        Projectile.NewProjectile(source, position.X, position.Y, speedX, speedY, ProjectileID.BookStaffShot, damage, knockBack, player.whoAmI);
        Projectile.NewProjectile(source, position.X, position.Y, speedX, speedY, ProjectileID.Ale, damage, knockBack, player.whoAmI);
        Projectile.NewProjectile(source, position.X, position.Y, speedX, speedY, ProjectileID.ToxicBubble, damage, knockBack, player.whoAmI);
        return true;
    }

    private class MyGlobalNPC : GlobalNPC
    {
        public override void OnKill(NPC npc) {
            if (npc.type == NPCID.CultistBoss) {
                Item.NewItem(npc.GetSource_FromAI(), npc.getRect(), ModContent.ItemType<AncientMonkys>(), 1);
            }
        }
    }
}