﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using jxGameFramework.Controls;
using jxGameFramework.Components;
using jxGameFramework.Data;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace jxGameFramework.Controls
{
    class CheckBox : Control
    {
        Sprite _checkcircle;
        Text _title;
        Font _fnt;

        Texture2D full;
        Texture2D empty;

        public string Text
        {
            get
            {
                return _title.text;
            }
            set
            {
                _title.text = value;
            }
        }
        bool _checked = false;
        public bool Checked
        {
            get
            {
                return _checked;
            }
            set
            {
                _checked = value;
                if(_checked)
                {
                    _checkcircle.Texture = full;
                }
                else
                {
                    _checkcircle.Texture = empty;
                }
            }
        }

        public override void LoadContent()
        {
            GDIpInterop gdip = new GDIpInterop(18, 18, GraphicsDevice);
            gdip.g.FillEllipse(System.Drawing.Brushes.White, 0, 0, 16, 16);
            full = gdip.SaveTexture();
            gdip.g.Clear(System.Drawing.Color.Transparent);
            System.Drawing.Pen p = new System.Drawing.Pen(System.Drawing.Color.White, 2);
            gdip.g.DrawEllipse(p, 0, 0, 16, 16);
            empty = gdip.SaveTexture();

            _fnt = new Font(GraphicsDevice, "msyh.ttc", 15)
            {
                EnableShadow = true,
                ShadowColor = Color.Black,
                ShadowYOffset = 1,
            };
            _checkcircle = new Sprite()
            {
                Texture = empty,
                Margin=Origins.CenterLeft,
                Left = 2,
                Color=Color.DeepPink,
            };
            _checkcircle.Width = _checkcircle.Texture.Width;
            _checkcircle.Height = _checkcircle.Texture.Height;

            _title = new Text()
            {
                Font = _fnt,
                Color = Color.White,
                OriginType = Origins.CenterLeft,
                X = 22,
                Y = 7,
            };
            AddComponent(_title);
            AddComponent(_checkcircle);
            this.Width = full.Width;
            this.Height = full.Height;
            this.Click += CheckBox_Click;
            base.LoadContent();
        }

        void CheckBox_Click(object sender, EventArgs e)
        {
            this.Checked = !this.Checked;
        }
        
    }
}
